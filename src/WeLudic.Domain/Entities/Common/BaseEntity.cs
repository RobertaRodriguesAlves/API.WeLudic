using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Entities.Common;

public abstract class BaseEntity : IEntity<Guid>
{
    public Guid Id { get; } = Guid.NewGuid();
}
