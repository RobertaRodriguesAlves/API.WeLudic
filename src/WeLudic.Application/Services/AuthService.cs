using FluentResults;
using Microsoft.Extensions.Logging;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Responses;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Security.Interfaces;
using WeLudic.Shared.Errors;
using WeLudic.Shared.Extensions;
using WeLudic.Shared.Models;
using BC = BCrypt.Net;

namespace WeLudic.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _service;
    private readonly IUserRepository _repository;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        ITokenService service,
        IUserRepository repository,
        ILogger<AuthService> logger)
    {
        _service = service;
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<SignupResponse>> SignUpAsync(SignUpRequest request)
    {
        _logger.LogInformation("Validando informações recebidas");

        await request.ValidateAsync();
        if (!request.IsValid)
            return request.ToFail();

        var user = await _repository.GetByEmailAsync(request.Email);
        if (user is not null)
        {
            _logger.LogError($"{request.Email} já cadastrado.");
            return Result.Fail(new ForbiddenError("Email já cadastrado."));
        }

        var createdUser = await _repository.CreateAsync(new User().SetUser(
                                                        request.Name,
                                                        request.Email,
                                                        BC.BCrypt.HashPassword(request.Password)));

        _logger.LogInformation("Gerando credenciais de acesso");

        var accessKeys = _service.CreateAccessKeys(createdUser.Id, createdUser.Email);

        await UpdateAccessInformationAsync(createdUser, accessKeys);

        return Result.Ok(new SignupResponse(
            new TokenResponse(accessKeys.AccessToken, accessKeys.CreatedAt, accessKeys.Expiration, accessKeys.RefreshToken),
            new UserResponse(createdUser.Id, createdUser.Name, createdUser.Email)));
    }

    public async Task<Result<SigninResponse>> SignInAsync(SignInRequest request)
    {
        _logger.LogInformation("Validando informações recebidas");

        await request.ValidateAsync();
        if (!request.IsValid)
            return request.ToFail();

        _logger.LogInformation("Consultando informações.");

        var user = await _repository.GetByEmailAsync(request.Email);
        if (user is null ||
            !BC.BCrypt.Verify(request.Password, user.HashedPassword))
        {
            _logger.LogError("Acesso negado, informações não encontradas ou não conferem.");
            return Result.Fail(new ForbiddenError("Acesso negado"));
        }

        var accessKeys = _service.CreateAccessKeys(user.Id, user.Email);

        await UpdateAccessInformationAsync(user, accessKeys);

        return Result.Ok(new SigninResponse(
            new TokenResponse(accessKeys.AccessToken, accessKeys.CreatedAt, accessKeys.Expiration, accessKeys.RefreshToken),
            new UserResponse(user.Id, user.Name, user.Email)));
    }

    public async Task<Result<TokenResponse>> RefreshAuthenticationAsync(RefreshAuthenticationRequest request)
    {
        _logger.LogInformation("Validando informações recebidas");

        await request.ValidateAsync();
        if (!request.IsValid)
            return request.ToFail();

        var user = await _repository.GetByIdAsync(request.Id);
        if (user is null ||
            !BC.BCrypt.Verify(request.RefreshToken, user.RefreshToken) ||
            DateTime.UtcNow > user?.ExpirationAt)
        {
            _logger.LogError("Acesso negado, informações inválidas ou expiradas.");
            return Result.Fail(new ForbiddenError("Acesso negado"));
        }

        var accessKeys = _service.CreateAccessKeys(user.Id, user.Email);

        await UpdateAccessInformationAsync(user, accessKeys);

        return Result.Ok(new TokenResponse(accessKeys.AccessToken, accessKeys.CreatedAt, accessKeys.Expiration, accessKeys.RefreshToken));
    }

    public async Task<Result> LogoutAsync(Guid userId)
    {
        if (string.IsNullOrWhiteSpace(userId.ToString()))
            return Result.Fail(new ValidationError("Informação inválida"));

        var user = await _repository.GetByIdAsync(userId);
        if (user is null)
        {
            _logger.LogError("Usuário não encontrado.");
            return Result.Fail(new NotFoundError("Usuário não encontrado."));
        }

        user.SetRefreshToken(string.Empty, null);
        await _repository.UpdateAsync(user);

        return Result.Ok();
    }

    public async Task<Result<UserResponse>> GetCurrentUserAsync(Guid userId)
    {
        if (string.IsNullOrWhiteSpace(userId.ToString()))
            return Result.Fail(new ValidationError("Informação inválida"));

        var user = await _repository.GetByIdAsync(userId);

        return Result.Ok(new UserResponse(user?.Id, user?.Name, user?.Email));
    }

    #region Private Methods

    private async Task UpdateAccessInformationAsync(User createdUser, AccessKeys accessKeys)
    {
        _logger.LogInformation("Atualizando informações de acesso do usuário");

        createdUser.SetAccessToken(BC.BCrypt.HashPassword(accessKeys.AccessToken));
        createdUser.SetRefreshToken(BC.BCrypt.HashPassword(accessKeys.RefreshToken), accessKeys.RefreshTokenExpiration);
        await _repository.UpdateAsync(createdUser);
    }

    #endregion

    #region IDisposable

    // To detect redundant calls.
    private bool _disposed;

    // Public implementation of Dispose pattern callable by consumers.
    ~AuthService()
    {
        Dispose(false);
    }

    // Protected implementation of Dispose pattern.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        // Dispose managed state (managed objects).
        if (disposing)
            _repository.Dispose();

        _disposed = true;
    }

    #endregion
}
