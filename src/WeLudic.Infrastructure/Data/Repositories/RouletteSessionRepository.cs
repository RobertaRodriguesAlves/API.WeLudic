using Microsoft.EntityFrameworkCore;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Data.Context;
using WeLudic.Infrastructure.Data.Repositories.Common;

namespace WeLudic.Infrastructure.Data.Repositories;

public class RouletteSessionRepository : BaseRepository<RouletteSession>, IRouletteSessionRepository
{
    public RouletteSessionRepository(WeLudicContext context) : base(context) { }

    public async Task<Guid> CreateSessionAsync(RouletteSession roulette, CancellationToken cancellationToken = default)
    {
        DbSet.Add(roulette);
        await SaveChangesAsync(cancellationToken);

        return roulette.Id;
    }

    public async Task<bool> ExistsAsync(Guid sessionId, CancellationToken cancellationToken = default)
       => await DbSet
            .AsNoTracking()
            .AnyAsync(p => p.Id.Equals(sessionId), cancellationToken);
}
