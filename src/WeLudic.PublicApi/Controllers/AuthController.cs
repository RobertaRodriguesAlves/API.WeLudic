using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Responses.Auth;
using WeLudic.Shared.Extensions;
using WeLudic.Shared.Responses;

namespace WeLudic.PublicApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service) => _service = service;

    /// <summary>
    /// Cadastrar credenciais do usuário para acesso à aplicação
    /// </summary>
    /// <response code="200"> Retorna chaves de acesso.</response>
    /// <response code="500"></response>
    [AllowAnonymous]
    [HttpPost("signup")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<SignupResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        => (await _service.SignUpAsync(request)).ToActionResult();

    /// <summary>
    /// Cadastrar credenciais do paciente para acesso à aplicação
    /// </summary>
    /// <response code="200"> Retorna chaves de acesso.</response>
    /// <response code="500"></response>
    [AllowAnonymous]
    [HttpPost("signuppatient")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<SignupPatientResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SignUpPatient([FromBody] SignUpPatientRequest request)
        => (await _service.SignUpPatientAsync(request)).ToActionResult();

    /// <summary>
    /// Acessar aplicação.
    /// </summary>
    /// <response code="200"> Retorna chaves de acesso.</response>
    /// <response code="500"></response>
    [AllowAnonymous]
    [HttpPost("signin")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<SigninResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        => (await _service.SignInAsync(request)).ToActionResult();

    /// <summary>
    /// Atualizar credenciais de acesso.
    /// </summary>
    /// <response code="200"> Retorna chaves de acesso.</response>
    /// <response code="500"></response>
    [AllowAnonymous]
    [HttpPost("refresh-token")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<TokenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshAuthenticationRequest request)
        => (await _service.RefreshAuthenticationAsync(request)).ToActionResult();

    /// <summary>
    /// Desloga da aplicação.
    /// </summary>
    [HttpPost("logout")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<TokenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Logout()
        => (await _service.LogoutAsync()).ToActionResult();

    /// <summary>
    /// Retorna informações do usuário logado.
    /// </summary>
    [HttpGet("me")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<PatientResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCurrentUser()
        => (await _service.GetCurrentUserAsync()).ToActionResult();
}
