using WeLudic.Shared.Responses;

namespace WeLudic.Application.Responses;

public sealed class TokenResponse : BaseResponse
{
    public TokenResponse(string accessToken, DateTime createdAt, DateTime expiresAt, string refreshToken)
    {
        AccessToken = accessToken;
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
        RefreshToken = refreshToken;
    }

    /// <summary>
    /// Token de acesso.
    /// </summary>
    public string AccessToken { get; }

    /// <summary>
    /// Data de criação do token.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// Data do vencimento do token.
    /// </summary>
    public DateTime ExpiresAt { get; }

    /// <summary>
    /// Token de atualização.
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    /// Expiração do token em segundos.
    /// </summary>
    public int ExpiresIn => (int)ExpiresAt.Subtract(CreatedAt).TotalSeconds;
}
