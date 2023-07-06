using WeLudic.Domain.Entities.Common;

namespace WeLudic.Domain.Entities;
public sealed class User : BaseAuditEntity
{
    public string Name { get; }
    public Email Email { get; }
    public string HashedPassword { get; }
}
