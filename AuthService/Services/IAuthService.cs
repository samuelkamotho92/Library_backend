using AuthService.Dto;
using AuthService.Model;

namespace AuthService.Services
{
    public interface IAuthService
    {
        public  Task<string> RegisterUser(RegisterUserDto user);

        public Task<User> GetUser(string Suboid);
    }
}
