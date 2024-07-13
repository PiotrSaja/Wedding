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
            try
            {
                return Ok(await UserService.Login(model));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Register([FromBody] RegisterRequestModel model)
        {
            try
            {
                await UserService.Register(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
