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
        public async Task<ActionResult> Login([FromBody] LoginRequestModel model)
        {
            return Ok(await UserService.Login(model));
        }

        [HttpPost("register")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Register([FromBody] RegisterRequestModel model)
        {
            await UserService.Register(model);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Test()
        {
            return Ok();
        }
    }
}
