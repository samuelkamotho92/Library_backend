using AutoMapper;
using Library.Dto;
using Library.Model;

namespace Library.Profiles
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto,Book>().ReverseMap();
        }
    }
}
