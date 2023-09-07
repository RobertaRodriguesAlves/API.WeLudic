using System.ComponentModel.DataAnnotations;

namespace WeLudic.Shared.AppSettings;

public sealed class SecuritySettings
{
    [Required]
    public string CriptographyKey { get; private init; }

    [Required]
    public string ClaimKey { get; private init; }

    [Required]
    public string SecretKey { get; private init; }

    [Required]
    public string Issuer { get; private init; }

    [Required]
    public string Audience { get; private init; }

    [Required]
    public int AccessTokenValidMinutes { get; private init; }

    [Required]
    public int RefreshTokenValidMinutes { get; private init; }
}
