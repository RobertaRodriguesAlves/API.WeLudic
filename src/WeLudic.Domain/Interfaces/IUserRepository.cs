using WeLudic.Domain.Entities;
using WeLudic.Domain.ValueObjects;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Interfaces;

public interface IUserRepository : IRepository
{
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
    Task<User> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);
}
