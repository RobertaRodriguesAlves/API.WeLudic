using WeLudic.Domain.Entities;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Interfaces;

public interface IRouletteSessionRepository : IRepository
{
    Task<Guid> CreateSessionAsync(RouletteSession roulette, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid sessionId, CancellationToken cancellationToken = default);
}