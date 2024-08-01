using Identity.Api.Models.Token;
using Identity.Api.Models.User;
using Identity.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IUserService userService) : ControllerBase
    {
        protected IUserService UserService { get; } = userService;

        [HttpPost("login")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Login([FromBody] LoginFormModel model)
        {
            return Ok(await UserService.Login(model));
        }

        [HttpPost("register")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Register([FromBody] RegisterFormModel model)
        {
            await UserService.Register(model);

            return Ok();
        }

        [Authorize]
        [HttpPost("validate")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RefreshToken([FromBody] ValidateTokenRequestModel request)
        {
            var tokenModel = await UserService.Validate(request);
            return Ok(tokenModel);
        }
    }
}
