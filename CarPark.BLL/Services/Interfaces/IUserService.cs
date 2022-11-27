using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface IUserService
    {
        Task<bool> SignUpAsync(UserForSignUpDto user);
        Task<string> SignInAsync(UserForSignInDto user);
    }
}