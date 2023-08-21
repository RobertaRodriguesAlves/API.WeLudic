using WeLudic.Domain.Entities;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Interfaces;

public interface IRouletteOptionsRepository : IRepository
{
    Task<IEnumerable<RouletteOption>> GetOptionsAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<RouletteOption>> GetOptionByIdAsync(IEnumerable<int> optionsId, CancellationToken cancellationToken = default);
}
