using FluentResults;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Responses;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Application.Interfaces;

public interface IAuthService : IAppService, IDisposable
{
    Task<Result<TokenResponse>> AuthenticationAsync(AuthenticationRequest request);
    Task<Result<TokenResponse>> RefreshAuthorizationAsync(RefreshAuthenticationRequest request);
}