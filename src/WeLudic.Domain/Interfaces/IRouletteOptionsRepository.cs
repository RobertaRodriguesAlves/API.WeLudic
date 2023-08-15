using WeLudic.Domain.Entities;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Interfaces;

public interface IRouletteOptionsRepository : IRepository
{
    Task<RouletteOption> GetOptionsAsync(Guid userId);
}
