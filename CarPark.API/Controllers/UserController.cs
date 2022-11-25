using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarPark.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(
            IConfiguration configuration,
            IUserService userService)
        {
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            _userService = userService ??
                throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<ResponseAPI>> Authenticate(UserForLoginDto userForLogin)
        {
            // Step 1: Validate the username/password
            var user = await _userService.ValidateUserCredentials(userForLogin);
            if (user == null)
            {
                return Unauthorized(new ResponseAPI
                {
                    Status = false,
                    Message = "No account exists!",
                    Data = null
                });
            }

            // Step 2: Create a token
            var token = _userService.GenerateToken(user);

            return Ok(new ResponseAPI
            {
                Status = true,
                Message = "Authenticate success",
                Data = token
            });
        }
    }
}
