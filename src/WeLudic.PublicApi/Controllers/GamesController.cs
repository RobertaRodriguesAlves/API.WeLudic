using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Games;
using WeLudic.Application.Responses.Games;
using WeLudic.Shared.Extensions;
using WeLudic.Shared.Responses;

namespace WeLudic.PublicApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly IGamesService _service;

    public GamesController(IGamesService service) => _service = service;

    /// <summary>
    /// Consulta as opções da roleta por usuário logado e por opções sem usuário cadastrado.
    /// </summary>
    /// <response code="200"> Retorna opções da roleta.</response>
    /// <response code="500"></response>
    [HttpGet("roulette-options")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<RouletteOptionsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRouletteOptionsAsync()
        => (await _service.GetRouletteOptions()).ToActionResult();

    /// <summary>
    /// Cria uma sessão para o usuário logado.
    /// </summary>
    /// <response code="200"> Retorna Id da sessão criada.</response>
    /// <response code="500"></response>
    [HttpPost("create-roulette-session")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<Guid>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateRouletteSessionAsync([FromBody] CreateRouletteSessionRequest request)
        => (await _service.CreateRouletteSessionAsync(request)).ToActionResult();

    /// <summary>
    /// Retorna as opções da roleta para a sessão id.
    /// </summary>
    /// <response code="200"> Retorna as opções da roleta.</response>
    /// <response code="500"></response>
    [HttpGet("roulette/game-options")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<RouletteOptionsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetGamesOptionsAsync(Guid sessionId)
        => (await _service.GetGameOptions(sessionId)).ToActionResult();
}
