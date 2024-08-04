using System.Security.Cryptography;

namespace Wedding.Api.Helpers
{
    #region IEncryptionHelper
    public interface IEncryptionHelper
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
    #endregion
    public class EncryptionHelper : IEncryptionHelper
    {
        private static byte[] _key;
        private static byte[] _iv;

        public EncryptionHelper(IConfiguration configuration)
        {
            var key = configuration["Encryption:Key"];
            var iv = configuration["Encryption:IV"];

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(iv))
                throw new ArgumentNullException("Encryption key and IV must be provided");

            _key = Convert.FromBase64String(key);
            _iv = Convert.FromBase64String(iv);

            if (_key.Length != 16 && _key.Length != 24 && _key.Length != 32)
                throw new ArgumentException("Invalid key size. Key must be 16, 24, or 32 bytes.");

            if (_iv.Length != 16)
                throw new ArgumentException("Invalid IV size. IV must be 16 bytes.");
        }

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
