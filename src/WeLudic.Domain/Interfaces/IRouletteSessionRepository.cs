using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Interfaces;

public interface IRouletteSessionRepository : IRepository
{
    Task<Guid> CreateSessionAsync(Guid userId, IEnumerable<int> options, CancellationToken cancellationToken = default);
}