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

        [HttpPost("signup")]
        public async Task<ActionResult> SignUpAsync(UserForSignUpDto user)
        {
            try
            {
                await _userService.SignUpAsync(user);
                return Ok(new ResponseAPI
                {
                    Status = true,
                    Message = "Registration success"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseAPI
                {
                    Status = false,
                    Message = $"Registration failed!\n{e.Message}"
                });
            }
        }

        [HttpPost("signin")]
        public async Task<ActionResult<ResponseAPI>> SignInAsync(UserForSignInDto user)
        {
            var token = await _userService.SignInAsync(user);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new ResponseAPI
                {
                    Status = false,
                    Message = "No account exists!",
                    Data = null
                });
            }

            return Ok(new ResponseAPI
            {
                Status = true,
                Message = "Authenticate success",
                Data = token
            });
        }
    }
}
