using FluentResults;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Responses.Auth;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Application.Interfaces;

public interface IAuthService : IAppService, IDisposable
{
    Task<Result<SignupResponse>> SignUpAsync(SignUpRequest request);
    Task<Result<SigninResponse>> SignInAsync(SignInRequest request);
    Task<Result<TokenResponse>> RefreshAuthenticationAsync(RefreshAuthenticationRequest request);
    Task<Result> LogoutAsync();
    Task<Result<UserResponse>> GetCurrentUserAsync();
    Task<Result<SignupPatientResponse>> SignUpPatientAsync(SignUpPatientRequest request);
}