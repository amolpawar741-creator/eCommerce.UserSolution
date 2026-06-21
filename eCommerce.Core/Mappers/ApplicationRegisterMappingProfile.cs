using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Mappers;
public class ApplicationRegisterMappingProfile:Profile
{
    public ApplicationRegisterMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(e => e.Email))
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(r => r.PersonName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(e => e.Gender))
            ;
    }
}

