using System.Linq;
using Angular.API.DTO;
using Angular.API.Models;
using AutoMapper;

namespace Angular.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => 
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailedDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => 
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailedDTO>();
            CreateMap<UserForUpdateDTO, User>();
        }
    }
}