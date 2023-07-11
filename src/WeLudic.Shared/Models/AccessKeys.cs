namespace WeLudic.Shared.Models;

public sealed record AccessKeys(
    string AccessToken,
    string RefreshToken,
    DateTime CreatedAt,
    DateTime Expiration,
    DateTime RefreshTokenExpiration);