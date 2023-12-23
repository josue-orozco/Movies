using AutoMapper;

namespace Movies.API.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Entities.Movie, Models.MovieDto>().ReverseMap();
        }
    }
}