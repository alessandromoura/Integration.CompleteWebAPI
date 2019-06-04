using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.CompleteWebAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.TeamEntity, Models.TeamDto>()
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TeamFoundation, opt => opt.MapFrom(src => src.FoundationDate))
                .ForMember(dest => dest.MascotImage, opt => opt.MapFrom(src => src.Mascot))
                .ForMember(dest => dest.LogoImage, opt => opt.MapFrom(src => src.Logo));
        }
    }
}
