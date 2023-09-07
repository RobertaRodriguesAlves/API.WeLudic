using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using WeLudic.Infrastructure.Security.Interfaces;
using WeLudic.Shared.AppSettings;

namespace WeLudic.Infrastructure.Security.Services;

public sealed class CryptService : ICryptService
{
    private readonly byte[] _key;
    private readonly byte[] _iv = new byte[16];

    public CryptService(IOptions<SecuritySettings> options)
        => _key = Encoding.ASCII.GetBytes(options.Value.CriptographyKey);

    public string Encrypt(string value)
    {
        byte[] encryptedValue;
        using (var aes = Aes.Create())
        {
            var encryptor = aes.CreateEncryptor(_key, _iv);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(value);
            }

            encryptedValue = memoryStream.ToArray();
        }

        return Convert.ToBase64String(encryptedValue);
    }

    public string Decrypt(string encryptedValue)
    {
        var decryptedValue = string.Empty;
        using (var aes = Aes.Create())
        {
            var decryptor = aes.CreateDecryptor(_key, _iv);
            using var memoryStream = new MemoryStream(GetBytes(encryptedValue));
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);
            decryptedValue = streamReader.ReadToEnd();
        }
        return decryptedValue;
    }

    public bool Verify(string text, string hash)
        => text.Equals(Decrypt(hash), StringComparison.InvariantCultureIgnoreCase);

    #region "Private Methods"

    private static byte[] GetBytes(string value)
        => Convert.FromBase64String(value);

    #endregion
}
