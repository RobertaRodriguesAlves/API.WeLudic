using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WeLudic.Application.Hubs;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Responses.Auth;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Entities.Common;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Security.Interfaces;
using WeLudic.Shared.AppSettings;
using WeLudic.Shared.Errors;
using WeLudic.Shared.Extensions;
using WeLudic.Shared.Models;

namespace WeLudic.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _service;
    private readonly ICryptService _crypt;
    private readonly IUserRepository _repository;
    private readonly IPatientRepository _patientRepository;
    private readonly IRouletteSessionRepository _sessionRepository;
    private readonly ILogger<AuthService> _logger;
    private readonly IHubContext<AuthenticationHub> _authHubContext;

    private readonly SecuritySettings _settings;
    private readonly string _userId;

    public AuthService(
        ITokenService service,
        ICryptService crypt,
        IUserRepository repository,
        IPatientRepository patientRepository,
        IRouletteSessionRepository sessionRepository,
        IHttpContextAccessor httpAccessor,
        ILogger<AuthService> logger,
        IOptions<SecuritySettings> options,
        IHubContext<AuthenticationHub> authHubContext)
    {
        _service = service;
        _crypt = crypt;
        _repository = repository;
        _patientRepository = patientRepository;
        _sessionRepository = sessionRepository;
        _logger = logger;
        _settings = options.Value;
        _authHubContext = authHubContext;

        _userId = httpAccessor.HttpContext.User.Claims.FirstOrDefault(ac => ac.Type == _settings.ClaimKey)?.Value;
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
            _logger.LogError("Email já cadastrado.", request.Email);
            return Result.Fail(new ForbiddenError("Email já cadastrado."));
        }

        _logger.LogInformation("Criando login. Nome: {user} e Email: {email}.", request.Name, request.Email);
        var createdUser = await _repository.CreateAsync(new User().SetUser(
                                                        request.Name,
                                                        request.Email,
                                                        _crypt.Encrypt(request.Password)));

        _logger.LogInformation("Gerando credenciais de acesso");

        var accessKeys = _service.CreateAccessKeys(createdUser.Id, createdUser.Email);
        UpdateAccessInformation(createdUser, accessKeys);
        await _repository.UpdateAsync(createdUser);

        _logger.LogInformation("Credenciais criadas e atualizadas.");

        return Result.Ok(new SignupResponse(
            new TokenResponse(accessKeys.AccessToken, accessKeys.CreatedAt, accessKeys.Expiration, accessKeys.RefreshToken),
            new UserResponse(createdUser.Id, createdUser.Name, createdUser.Email, createdUser.ConfirmAndAgree)));
    }

    public async Task<Result<SigninResponse>> SignInAsync(SignInRequest request)
    {
        _logger.LogInformation("Validando informações recebidas");

        await request.ValidateAsync();
        if (!request.IsValid)
            return request.ToFail();

        _logger.LogInformation("Consultando informações do usuario pelo Email: {email}.", request.Email);

        var user = await _repository.GetByEmailAsync(request.Email);
        if (user is null ||
            !_crypt.Verify(request.Password, user.HashedPassword))
        {
            _logger.LogError("Acesso negado, informações não encontradas ou não conferem.");
            return Result.Fail(new UnauthorizedError("Acesso negado"));
        }

        var accessKeys = _service.CreateAccessKeys(user.Id, user.Email);
        UpdateAccessInformation(user, accessKeys);
        await _repository.UpdateAsync(user);

        _logger.LogInformation("Credenciais criadas e atualizadas.");

        return Result.Ok(new SigninResponse(
            new TokenResponse(accessKeys.AccessToken, accessKeys.CreatedAt, accessKeys.Expiration, accessKeys.RefreshToken),
            new UserResponse(user.Id, user.Name, user.Email, user.ConfirmAndAgree)));
    }

    public async Task<Result<TokenResponse>> RefreshAuthenticationAsync(RefreshAuthenticationRequest request)
    {
        _logger.LogInformation("Validando informações recebidas");

        await request.ValidateAsync();
        if (!request.IsValid)
            return request.ToFail();

        _logger.LogInformation("Verificando validade de Refresh Token.");

        var user = await _repository.GetByRefreshTokenAsync(_crypt.Encrypt(request.RefreshToken));
        if (user is null ||
            DateTime.UtcNow > user.ExpirationAt)
        {
            _logger.LogError("Acesso negado, informações inválidas ou expiradas.");
            return Result.Fail(new UnauthorizedError("Acesso negado"));
        }

        var accessKeys = _service.CreateAccessKeys(user.Id, user.Email);
        UpdateAccessInformation(user, accessKeys);
        await _repository.UpdateAsync(user);

        _logger.LogInformation("Credenciais criadas e atualizadas.");

        return Result.Ok(new TokenResponse(accessKeys.AccessToken, accessKeys.CreatedAt, accessKeys.Expiration, accessKeys.RefreshToken));
    }

    public async Task<Result> LogoutAsync()
    {
        if (!Guid.TryParse(_userId, out var userId))
        {
            _logger.LogError("Usuário não encontrado.");
            return Result.Fail(new NotFoundError("Usuário não encontrado"));
        }

        _logger.LogInformation("Consultando informações do usuario: {id}.", userId);

        var user = await _repository.GetByIdAsync(Guid.Parse(_userId));
        user.SetRefreshToken(string.Empty, null);
        await _repository.UpdateAsync(user);

        _logger.LogInformation("Logout realizado com sucesso.");

        return Result.Ok();
    }

    public async Task<Result<UserResponse>> GetCurrentUserAsync()
    {
        if (!Guid.TryParse(_userId, out var userId))
        {
            _logger.LogError("Usuário não encontrado.");
            return Result.Fail(new NotFoundError("Usuário não encontrado"));
        }

        _logger.LogInformation("Consultando informações do usuario: {id}.", userId);
        var user = await _repository.GetByIdAsync(userId);
        return Result.Ok(new UserResponse(user.Id, user.Name, user.Email, user.ConfirmAndAgree));
    }

    public async Task<Result<SignupPatientResponse>> SignUpPatientAsync(SignUpPatientRequest request)
    {
        _logger.LogInformation("Validando informações recebidas");

        await request.ValidateAsync();
        if (!request.IsValid)
            return request.ToFail();

        _logger.LogInformation("Validando existência de SessionID: {id}", request.SessionId);

        if (await _sessionRepository.ExistsAsync(request.SessionId))
        {
            _logger.LogInformation("Criando login. Nome: {user} e Sessao: {id}.", request.Name, request.SessionId);
            var createdPatient = await _patientRepository.CreateAsync(new Patient().SetPatient(
                                                                      request.Name,
                                                                      request.SessionId,
                                                                      request.ConfirmAndAgree));

            _logger.LogInformation("Gerando credenciais de acesso");

            var accessKeys = _service.CreateAccessKeys(createdPatient.Id, createdPatient.Name);
            UpdateAccessInformation(createdPatient, accessKeys);
            await _patientRepository.UpdateAsync(createdPatient);

            await _authHubContext.Clients.All.SendAsync("Connection", $"{createdPatient.Name} conectou.");

            _logger.LogInformation("Credenciais criadas e atualizadas.");

            return Result.Ok(new SignupPatientResponse(
                new TokenResponse(accessKeys.AccessToken, accessKeys.CreatedAt, accessKeys.Expiration, accessKeys.RefreshToken),
                new PatientResponse(createdPatient.Id, createdPatient.Name, createdPatient.ConfirmAndAgree)));
        }

        _logger.LogInformation("SessionId: {id} inexistente.", request.SessionId);

        return Result.Fail(new ForbiddenError("SessionId inválida"));
    }

    #region Private Methods

    private void UpdateAccessInformation(BaseSecurityEntity credentials, AccessKeys accessKeys)
    {
        _logger.LogInformation("Atualizando informações de acesso do usuário");

        credentials.SetAccessToken(_crypt.Encrypt(accessKeys.AccessToken));
        credentials.SetRefreshToken(_crypt.Encrypt(accessKeys.RefreshToken), accessKeys.RefreshTokenExpiration);
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
