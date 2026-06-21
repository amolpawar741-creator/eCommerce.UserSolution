using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Mappers;
public class ApplicationUserMapping : Profile
{
    public ApplicationUserMapping()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(s => s.UserId))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(e => e.Email))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(g => g.PersonName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(t => t.Gender))
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.Success, opt => opt.Ignore());
    }
}

