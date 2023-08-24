using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Entities.Common;

/// <summary>
/// Classe que contém os comportamentos de uma entidade auditável.
/// </summary>
public abstract class BaseAuditEntity : IAudit
{
    public DateTime CreatedAt { get; private init; } = DateTime.UtcNow;
    public bool IsDeleted { get; private set; }
    public DateTime? LastModified { get; private set; }
    public Guid? LastModifiedBy { get; private set; }

    public BaseAuditEntity SetModified(Guid? userId, DateTime lastModified)
    {
        LastModifiedBy = userId;
        LastModified = lastModified;
        return this;
    }

    public BaseAuditEntity SetDeleted(Guid? userId, DateTime lastModified)
    {
        LastModifiedBy = userId;
        LastModified = lastModified;
        IsDeleted = true;
        return this;
    }
}
