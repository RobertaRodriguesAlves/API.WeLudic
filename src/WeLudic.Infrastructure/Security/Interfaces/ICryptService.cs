namespace WeLudic.Infrastructure.Security.Interfaces;

public interface ICryptService
{
    string Encrypt(string value);
    string Decrypt(string encryptedValue);
    bool Verify(string text, string hash);
}
