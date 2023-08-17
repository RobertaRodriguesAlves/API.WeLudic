using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Data.Context;
using WeLudic.Infrastructure.Data.Repositories.Common;

namespace WeLudic.Infrastructure.Data.Repositories;

public class RouletteSessionRepository : BaseRepository<RouletteSession>, IRouletteSessionRepository
{
    public RouletteSessionRepository(WeLudicContext context) : base(context) { }

    public Task<Guid> CreateSessionAsync(Guid userId, IEnumerable<int> options, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
