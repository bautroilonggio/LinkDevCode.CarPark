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

        public async Task<bool> SignUpAsync(UserForSignUpDto user)
        {
            var userEntity = _mapper.Map<User>(user);

            _unitOfWork.UserRepository.Add(userEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }

        public async Task<string> SignInAsync(UserForSignInDto user)
        {
            var userEntity = await _unitOfWork.UserRepository
                .GetSingleConditionsAsync(u => u.UserName == user.UserName && u.Password == user.Password);

            if(userEntity == null)
            {
                return string.Empty;
            }

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", userEntity.UserName));
            claimsForToken.Add(new Claim("given_name", userEntity.FirstName));
            claimsForToken.Add(new Claim("family_name", userEntity.Lastname));
            claimsForToken.Add(new Claim("email", userEntity.Email));
            claimsForToken.Add(new Claim("phone", userEntity.PhoneNumber));
            claimsForToken.Add(new Claim("role", userEntity.Role));

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims: claimsForToken,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signingCredentials);

            var jwtToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return jwtToReturn;
        }
    }
}
