using WeLudic.Domain.Entities;
using WeLudic.Domain.ValueObjects;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Interfaces;

public interface IUserRepository : IRepository
{
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
    Task<User> GetAsync(Email email, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);
}
