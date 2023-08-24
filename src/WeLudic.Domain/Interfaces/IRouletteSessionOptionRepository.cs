using WeLudic.Domain.Entities;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Interfaces;

public interface IRouletteSessionOptionRepository : IRepository
{
    Task CreateSessionOptionAsync(Guid sessionId, IEnumerable<int> options, CancellationToken cancellationToken = default);
    Task<IEnumerable<RouletteSessionOption>> GetOptionsBySessionIdAsync(Guid sessionId, CancellationToken cancellationToken = default);
}
