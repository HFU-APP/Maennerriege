
namespace Wettkampf.Services
{
  public interface IPasswordEncryptionService
  {
    byte[] Encrypt(byte[] input, byte[] key);

    byte[] Decrypt(byte[] input, byte[] key);

    byte[] GenerateKey(string passphrase);
  }
}
