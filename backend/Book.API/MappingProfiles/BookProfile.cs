using AutoMapper;
using Book.API.Dtos;

namespace Book.API.MappingProfiles
{
    public class BookProfile: Profile
    {
        public BookProfile() {
            CreateMap<Entities.Book, BookDto>();
        }
    }
}
