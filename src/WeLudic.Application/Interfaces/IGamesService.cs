using FluentResults;
using WeLudic.Application.Responses.Games;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Application.Interfaces;

public interface IGamesService : IAppService, IDisposable
{
    Task<Result<RouletteOptionsResponse>> GetRouletteOptions(Guid userId);
}
