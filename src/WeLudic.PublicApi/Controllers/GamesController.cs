using Microsoft.AspNetCore.Mvc;
using WeLudic.Application.Interfaces;

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
}
