using AuthService.Dto;
using AuthService.Model;
using AutoMapper;

namespace AuthService.Profiles
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
          CreateMap<RegisterUserDto,User>().ForMember(dest=>dest.UserName,src=>src.MapFrom(r=>r.Email));
        }
    }
}
