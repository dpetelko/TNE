using AutoMapper;
using TNE.Dto;
using TNE.Models;

namespace TNE.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeadDivision, LeadDivisionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Address.Id))
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.Address.PostCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Address.Region))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Building, opt => opt.MapFrom(src => src.Address.Building))
                .ReverseMap();
        }

    }
}
