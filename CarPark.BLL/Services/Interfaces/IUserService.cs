using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface IUserService
    {
        Task<UserToReturnDto?> ValidateUserCredentials(UserForLoginDto user);
        string GenerateToken(UserToReturnDto user);
    }
}