using AutoMapper;
using MovieAPI.DTOs;
using MovieAPI.Entities;

namespace MovieAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<GenreCreationDTO, Genre>();

        }
    }
}
