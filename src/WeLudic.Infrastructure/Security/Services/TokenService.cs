using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WeLudic.Domain.ValueObjects;
using WeLudic.Infrastructure.Security.Interfaces;
using WeLudic.Shared.AppSettings;
using WeLudic.Shared.Models;

namespace WeLudic.Infrastructure.Security.Services;

public sealed class TokenService : ITokenService
{
    private readonly SecuritySettings _settings;

    public TokenService(IOptions<SecuritySettings> options) => _settings = options.Value;

    public AccessKeys CreateAccessKeys(Guid id, Email email)
    {
        var claims = GenerateClaims(id, email);
        var jwtSecurityToken = GenerateJwtSecurityToken(claims);
        var createdAt = jwtSecurityToken.ValidFrom;
        var expiresAt = jwtSecurityToken.ValidTo;
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = expiresAt.Add(TimeSpan.FromMinutes(_settings.RefreshTokenValidMinutes));
        return new(accessToken, refreshToken, createdAt, expiresAt, refreshTokenExpiration);
    }

    #region Private Methods

    private IEnumerable<Claim> GenerateClaims(Guid id, Email email)
        => new List<Claim>
           {
               new Claim(ClaimTypes.NameIdentifier, email.Address),
               new Claim(_settings.ClaimKey, id.ToString())
           };

    private JwtSecurityToken GenerateJwtSecurityToken(IEnumerable<Claim> claims)
    {
        var key = Encoding.UTF8.GetBytes(_settings.SecretKey);

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var createdDate = DateTime.UtcNow;
        var expireDate = createdDate.Add(TimeSpan.FromMinutes(_settings.AccessTokenValidMinutes));

        var jwtHandler = new JwtSecurityTokenHandler();
        return jwtHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _settings.Issuer,
            Audience = _settings.Audience,
            SigningCredentials = credentials,
            NotBefore = createdDate,
            Expires = expireDate,
        });

    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    #endregion
}
