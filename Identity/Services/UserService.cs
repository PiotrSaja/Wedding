using Encryption;
using Identity.Api.Data.Models;
using Identity.Api.Exceptions;
using Identity.Api.Models.Token;
using Identity.Api.Models.User;
using Identity.Api.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Services
{
    #region IUserService
    public interface IUserService
    {
        Task<TokenModel> Login(LoginFormModel model);
        Task<bool> Register(RegisterFormModel model);
        Task<TokenModel> Validate(ValidateTokenRequestModel model);
    }
    #endregion 
    public class UserService(IUserRepository user, IEncryptor encryptor, ITokenService tokenService) : IUserService
    {
        protected IUserRepository User { get; } = user;
        protected IEncryptor Encryptor { get; } = encryptor;
        protected ITokenService TokenService { get; } = tokenService;

        public async Task<TokenModel> Login(LoginFormModel model)
        {
            var user = await User.GetUserByEmail(model.Email);

            if (user is null)
                throw new UserNotFoundException();

            var validateStatus = user.ValidatePassword(model.Password, encryptor);

            if (validateStatus == false) throw new UserNotFoundException();

            var token = TokenService.CreateToken(user);

            var tokenModel = new TokenModel()
            {
                ExpirationDateUtc = DateTime.UtcNow,
                Tokens = new Dictionary<string, string>()
                {
                    { TokenType.ACCESS.ToString(), token },
                    { TokenType.REFRESH.ToString(), string.Empty },
                }
            };

            return tokenModel;
        }

        public async Task<bool> Register(RegisterFormModel model)
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

        public async Task<TokenModel> Validate(ValidateTokenRequestModel model)
        {
            var userId = string.Empty;

            var storedRefreshToken = await TokenService.GetStoredRefreshToken(userId);

            if (storedRefreshToken != model.RefreshToken)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            var user = await User.GetById(Convert.ToInt32(userId));

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var newAccessToken = TokenService.CreateToken(user);
            var newRefreshToken = TokenService.GenerateRefreshToken();

            await TokenService.StoreRefreshToken(userId, newRefreshToken);

            var tokenModel = new TokenModel()
            {
                ExpirationDateUtc = DateTime.UtcNow.AddHours(1),
                Tokens = new Dictionary<string, string>()
                {
                    { TokenType.ACCESS.ToString(), newAccessToken },
                    { TokenType.REFRESH.ToString(), newRefreshToken },
                }
            };

            await TokenService.RemoveStoredRefreshToken(userId);

            return tokenModel;
        }
    }
}
