using Microsoft.EntityFrameworkCore;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Data.Context;
using WeLudic.Infrastructure.Data.Repositories.Common;

namespace WeLudic.Infrastructure.Data.Repositories;

public class RouletteSessionOptionRepository : BaseRepository<RouletteSessionOption>, IRouletteSessionOptionRepository
{
    public RouletteSessionOptionRepository(WeLudicContext context) : base(context) { }

    public async Task CreateSessionOptionAsync(Guid sessionId, IEnumerable<int> options, CancellationToken cancellationToken = default)
    {
        var sessionOptions = new List<RouletteSessionOption>();
        foreach (var item in options)
            sessionOptions.Add(new RouletteSessionOption().SetRouletteSessionOption(sessionId, item));

        DbSet.AddRange(sessionOptions);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<RouletteSessionOption>> GetOptionsBySessionIdAsync(Guid sessionId, CancellationToken cancellationToken = default)
      => await DbSet
            .AsNoTracking()
            .Where(p => p.RouletteSessionId.Equals(sessionId))
            .ToListAsync();
}
