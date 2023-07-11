using FluentResults;
using Microsoft.Extensions.Logging;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Responses;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Entities.Common;
using WeLudic.Infrastructure.Security.Interfaces;
using WeLudic.Shared.Extensions;

namespace WeLudic.Application.Services;

public sealed class AuthService : IAuthService
{
    private readonly ITokenService _service;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        ITokenService service,
        ILogger<AuthService> logger)
    {
        _service = service;
        _logger = logger;
    }

    public async Task<Result<TokenResponse>> AuthenticationAsync(AuthenticationRequest request)
    {
        await request.ValidateAsync();
        if (!request.IsValid)
            return request.ToFail();

        _logger.LogInformation("Consultando ApiKey: {key}...", request.ApiKey);

        //var credenciais = await _repository.GetByIdAsync(request.ApiKey);
        //if (credenciais is null)
        //{
        //    _logger.LogInformation("ApiKey: {key} não encontrada.", request.ApiKey);
        //    return Result.Fail(new UnauthorizedError($"ApiKey: {request.ApiKey} não encontrada."));
        //}

        //var accessKeys = _service.CreateAccessKeys(credenciais.Email, IsAdmin(credenciais.Email));
    }

    public Task<Result<TokenResponse>> RefreshAuthorizationAsync(RefreshAuthenticationRequest request)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    #region Private Methods

    private static bool IsAdmin(Guid id) => id == BaseEntity.AdminId;

    private async Task UpdateCredentialsAsync(User )
    #endregion
}
