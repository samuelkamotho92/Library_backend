
using AuthService.Data;
using AuthService.Dto;
using AuthService.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Services
{
    public class AuthServices : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public AuthServices(AuthDbContext context,UserManager<User> userManager,IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<User> GetUser(string Suboid)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.SubOid == Suboid);
            Console.WriteLine(user);
            return user;
        }

        //Get based on ID
        /*   public Task<User> GetUser(string Suboid)
           {

           }*/

        public  async Task<string> RegisterUser(RegisterUserDto userDto)
        {

            //check if user does exist 

            try
            {
               var user = _mapper.Map<User>(userDto);
               var result = await _userManager.CreateAsync(user);
                if(result.Succeeded)
                {
                    return string.Empty;
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }catch(Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }
        //Get user by ID 
    }
}
