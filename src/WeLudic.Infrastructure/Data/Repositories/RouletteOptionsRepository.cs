using Microsoft.EntityFrameworkCore;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Data.Context;
using WeLudic.Infrastructure.Data.Repositories.Common;

namespace WeLudic.Infrastructure.Data.Repositories;

public class RouletteOptionsRepository : BaseRepository<RouletteOption>, IRouletteOptionsRepository
{
    public RouletteOptionsRepository(WeLudicContext context) : base(context) { }

    public async Task<IEnumerable<RouletteOption>> GetOptionsAsync(Guid userId)
        => await DbSet
            .AsNoTracking()
            .Where(p => p.UserId.Equals(userId) || p.UserId == null)
            .ToListAsync();
}
