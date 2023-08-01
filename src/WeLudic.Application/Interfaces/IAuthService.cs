using FluentResults;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Responses;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Application.Interfaces;

public interface IAuthService : IAppService, IDisposable
{
    Task<Result<SignupResponse>> SignUpAsync(SignUpRequest request);
    Task<Result<SigninResponse>> SignInAsync(SignInRequest request);
    Task<Result<TokenResponse>> RefreshAuthenticationAsync(RefreshAuthenticationRequest request);
    Task<Result> LogoutAsync(Guid userId);
    Task<Result<UserResponse>> GetCurrentUserAsync(Guid userId);
}