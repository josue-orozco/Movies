using AutoMapper;

namespace Movies.API.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Entities.Actor, Models.ActorDto>().ReverseMap();
        }
    }
}
