using Microsoft.EntityFrameworkCore;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Domain.ValueObjects;
using WeLudic.Infrastructure.Data.Context;
using WeLudic.Infrastructure.Data.Repositories.Common;

namespace WeLudic.Infrastructure.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(WeLudicContext context) : base(context) { }

    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        DbSet.Add(user);
        await SaveChangesAsync(cancellationToken);

        return user;
    }

    public async Task<User> GetAsync(Email email, CancellationToken cancellationToken = default)
        => await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Email.Address == email.Address, cancellationToken);

    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        DbSet.Update(user);
        await SaveChangesAsync(cancellationToken);
    }
}