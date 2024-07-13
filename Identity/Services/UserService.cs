using Encryption;
using Identity.Api.Data.Models;
using Identity.Api.Exceptions;
using Identity.Api.Repositories;

namespace Identity.Api.Services
{
    #region IUserService
    public interface IUserService
    {
        Task<TokenModel> Login(LoginRequestModel model);
        Task<bool> Register(RegisterRequestModel model);
        Task<TokenModel> Validate(ValidateTokenModel model);
    }
    #endregion 
    public class UserService(IUserRepository user, IEncryptor encryptor, ITokenService tokenService) : IUserService
    {
        protected IUserRepository User { get; } = user;
        protected IEncryptor Encryptor { get; } = encryptor;
        protected ITokenService TokenService { get; } = tokenService;

        public async Task<TokenModel> Login(LoginRequestModel model)
        {
            var user = await User.GetUserByEmail(model.Email);

            if (user is null)
                throw new UserNotFoundException();

            var validateStatus = user.ValidatePassword(model.Password, encryptor);

            if (validateStatus == false) throw new UserNotFoundException();

            var token = TokenService.CreateToken(user);

            return new TokenModel(token, DateTime.UtcNow);
        }

        public async Task<bool> Register(RegisterRequestModel model)
        {
            var entity = new User()
            {
                Email = model.Email,
                IsVerified = false
            };

            entity.SetPassword(model.Password, encryptor);
            await User.Add(entity);

            return true;
        }

        public Task<TokenModel> Validate(ValidateTokenModel model)
        {
            //todo Implement a refresh token method
            throw new NotImplementedException();
        }
    }

    public record TokenModel(string Token, DateTime ExpirationDate);
    public record ValidateTokenModel(string Token, string RefreshToken, DateTime ExpirationDate);
    public record LoginRequestModel(string Email, string Password);
    public record RegisterRequestModel(string Email, string Password);
}
