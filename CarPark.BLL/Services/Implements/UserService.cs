using AutoMapper;
using CarPark.DAL;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarPark.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<UserToReturnDto?> ValidateUserCredentials(UserForLoginDto user)
        {
            var userEntity = await _unitOfWork.UserRepository
                .GetSingleConditionsAsync(u => u.UserName == user.UserName && u.Password == user.Password);

            var userToReturn = _mapper.Map<UserToReturnDto>(userEntity);

            return userToReturn;
        }

        public string GenerateToken(UserToReturnDto user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            // The claims that
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserName));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.Lastname));
            claimsForToken.Add(new Claim("phone", user.PhoneNumber));
            claimsForToken.Add(new Claim("email", user.Email));
            claimsForToken.Add(new Claim("address", user.Address));
            claimsForToken.Add(new Claim("role", user.Role));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(5),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn;
        }
    }
}
