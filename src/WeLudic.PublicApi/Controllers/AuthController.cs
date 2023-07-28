using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Responses;
using WeLudic.Shared.Extensions;
using WeLudic.Shared.Responses;

namespace WeLudic.PublicApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service) => _service = service;

    /// <summary>
    /// Cadastrar credenciais de acesso à aplicação
    /// </summary>
    /// <response code="200"> Retorna chaves de acesso.</response>
    /// <response code="500"></response>
    [HttpPost("SignUp")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<SignupResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        => (await _service.SignUpAsync(request)).ToActionResult();

    /// <summary>
    /// Acessar aplicação.
    /// </summary>
    /// <response code="200"> Retorna chaves de acesso.</response>
    /// <response code="500"></response>
    [HttpPost("SignIn")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<SigninResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        => (await _service.SignInAsync(request)).ToActionResult();

}
