using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Frameworks.Commands.CreateFramework;
using Kodlama.io.Devs.Application.Features.Frameworks.DTOs;
using Kodlama.io.Devs.Application.Features.Frameworks.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Framework, FrameworkListDto>()
                .ForMember(x => x.LanguageName, opt => opt.MapFrom(x => x.Language.Name));


            CreateMap<IPaginate<Framework>,FrameworkListModel>().ReverseMap();

            CreateMap<Framework, CreateFrameworkDto>().ReverseMap();
            CreateMap<Framework,CreateFrameworkCommand>().ReverseMap();
    
        }
    }
}