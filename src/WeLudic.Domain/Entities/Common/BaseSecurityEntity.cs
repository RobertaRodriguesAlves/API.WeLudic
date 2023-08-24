namespace WeLudic.Domain.Entities.Common;

/// <summary>
/// Classe que contém os comportamentos de uma entidade com credenciais de segurança.
/// </summary>
public abstract class BaseSecurityEntity : BaseAuditEntity
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string AccessToken { get; private set; }
    public string RefreshToken { get; private set; }
    public DateTime? GeneratedAt { get; private set; }
    public DateTime? ExpirationAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public BaseSecurityEntity SetAccessToken(string accessToken)
    {
        AccessToken = accessToken;
        GeneratedAt = DateTime.UtcNow;
        UpdatedAt = GeneratedAt;
        return this;
    }

    public BaseSecurityEntity SetRefreshToken(string refreshToken, DateTime? expirationAt)
    {
        RefreshToken = refreshToken;
        ExpirationAt = expirationAt;
        return this;
    }
}