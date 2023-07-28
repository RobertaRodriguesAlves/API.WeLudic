using WeLudic.Shared.Abstractions;

namespace WeLudic.Domain.Entities.Common;

/// <summary>
/// Classe que contém os comportamentos de uma entidade.
/// </summary>
public abstract class BaseAuditEntity: IAudit
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string AccessToken { get; private set; }
    public string RefreshToken { get; private set; }
    public DateTime? GeneratedAt { get; private set; }
    public DateTime? ExpirationAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime CreatedAt { get; private init; } = DateTime.UtcNow;
    public Guid? CreatedBy { get; private set; }
    public DateTime? LastModified { get; private set; }
    public Guid? LastModifiedBy { get; private set; }
    public bool IsDeleted { get; private set; }
    public long Version { get; private set; }

    public BaseAuditEntity SetAdded(Guid? userId)
    {
        CreatedBy = userId;
        Version++;
        return this;
    }

    public BaseAuditEntity SetModified(Guid? userId, DateTime lastModified)
    {
        LastModifiedBy = userId;
        LastModified = lastModified;
        Version++;
        return this;
    }

    public BaseAuditEntity SetDeleted(Guid? userId, DateTime lastModified)
    {
        LastModifiedBy = userId;
        LastModified = lastModified;
        IsDeleted = true;
        return this;
    }
    public BaseAuditEntity SetAccessToken(string accessToken)
    {
        AccessToken = accessToken;
        GeneratedAt = DateTime.UtcNow;
        UpdatedAt = GeneratedAt;
        return this;
    }

    public BaseAuditEntity SetRefreshToken(string refreshToken, DateTime expirationAt)
    {
        RefreshToken = refreshToken;
        ExpirationAt = expirationAt;
        return this;
    }
}