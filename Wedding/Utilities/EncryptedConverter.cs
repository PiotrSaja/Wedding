using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wedding.Api.Helpers;

namespace Wedding.Api.Utilities
{
    public class EncryptedConverter : ValueConverter<string, string>
    {
        public EncryptedConverter() : base(
            v => EncryptionHelper.Encrypt(v),
            v => EncryptionHelper.Decrypt(v))
        {
        }
    }
}
