using FluentResults;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Responses;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Application.Interfaces;

public interface IAuthService : IAppService, IDisposable
{
    Task<Result<SignupResponse>> SignUpAsync(SignUpRequest request);
    Task<Result<TokenResponse>> SignInAsync(SignInRequest request);
    Task<Result<TokenResponse>> RefreshAuthorizationAsync(RefreshAuthenticationRequest request);
}