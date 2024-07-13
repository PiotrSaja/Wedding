using BuildingBlocks.Data;
using Encryption;

namespace Identity.Api.Data.Models
{
    public sealed class User : IEntity
    {
        public int Id { get; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
        public string? Salt { get; set; }

        public void SetPassword(string password, IEncryptor encryptor)
        {
            Salt = encryptor.GetSalt();
            Password = encryptor.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncryptor encryptor) =>
            Password == encryptor.GetHash(password, Salt);
    }
}
