using WeLudic.Domain.Entities;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Interfaces;

public interface IUserRepository : IRepository
{
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
    Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);
}
