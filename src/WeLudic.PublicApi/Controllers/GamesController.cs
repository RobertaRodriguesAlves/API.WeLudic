using Microsoft.AspNetCore.Mvc;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Games;
using WeLudic.Shared.Extensions;

namespace WeLudic.PublicApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly IGamesService _service;

    public GamesController(IGamesService service) => _service = service;

    [HttpGet("roulette-options")]
    public async Task<IActionResult> GetRouletteOptionsAsync()
        => (await _service.GetRouletteOptions()).ToActionResult();

    [HttpPost("create-roulette-session")]
    public async Task<IActionResult> CreateRouletteSessionAsync([FromBody] CreateRouletteSessionRequest request)
        => (await _service.CreateRouletteSessionAsync(request)).ToActionResult();
}
