namespace WeLudic.Shared.Models;

public sealed class AccessKeys
{
    public string AccessToken { get; private set; }
    public string RefreshToken { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime Expiration { get; private set; }
    public DateTime RefreshTokenExpiration { get; private set; }

    public AccessKeys SetAccessToken(string accessToken, DateTime createdAt, DateTime expiration)
    {
        AccessToken = accessToken;
        CreatedAt = createdAt;
        Expiration = expiration;
        return this;
    }

    public AccessKeys SetRefreshToken(string refreshToken, DateTime refreshTokenExpiration)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiration = refreshTokenExpiration;
        return this;
    }
}