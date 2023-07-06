using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Entities.Common;

/// <summary>
/// Classe que contém os comportamentos de uma entidade auditável.
/// </summary>
public abstract class BaseAuditEntity : BaseEntity, IAudit
{
    public DateTime CreatedAt { get; private set; }
    public Guid? CreatedBy { get; private set; }
    public DateTime? LastModified { get; private set; }
    public Guid? LastModifiedBy { get; private set; }
    public bool IsDeleted { get; private set; }
    public long Version { get; private set; }

    public void SetAdded(Guid? userId, DateTime createdAt)
    {
        CreatedBy = userId;
        CreatedAt = createdAt;
        Version++;
    }

    public void SetModified(Guid? userId, DateTime lastModified)
    {
        LastModifiedBy = userId;
        LastModified = lastModified;
        Version++;
    }

    public void SetDeleted(Guid? userId, DateTime lastModified)
    {
        LastModifiedBy = userId;
        LastModified = lastModified;
        IsDeleted = true;
    }
}