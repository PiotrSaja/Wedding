using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wedding.Api.Helpers;

namespace Wedding.Api.Utilities
{
    public class EncryptedConverter : ValueConverter<string, string>
    {
        public EncryptedConverter(IEncryptionHelper encryptionHelper) : base(
            v => encryptionHelper.Encrypt(v),
            v => encryptionHelper.Decrypt(v))
        {
        }
    }
}
