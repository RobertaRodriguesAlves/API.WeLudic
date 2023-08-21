using FluentResults;
using WeLudic.Application.Requests.Games;
using WeLudic.Application.Responses.Games;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Application.Interfaces;

public interface IGamesService : IAppService, IDisposable
{
    Task<Result<IEnumerable<RouletteOptionsResponse>>> GetRouletteOptions();
    Task<Result<Guid>> CreateRouletteSessionAsync(CreateRouletteSessionRequest request);
    Task<Result<IEnumerable<RouletteOptionsResponse>>> GetGameOptions(Guid sessionId);
}
