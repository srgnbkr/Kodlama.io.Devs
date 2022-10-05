using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Languages.DTOs;
using Kodlama.io.Devs.Application.Features.Languages.Models;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.DTOs;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim, CreateOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();

            CreateMap<OperationClaim, UpdateOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();

            CreateMap<OperationClaim, DeleteOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();

            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();

        }
    }
}





    

