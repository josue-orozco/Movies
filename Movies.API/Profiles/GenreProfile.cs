using AutoMapper;

namespace Movies.API.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Entities.Genre, Models.GenreDto>().ReverseMap();
        }
    }
}
