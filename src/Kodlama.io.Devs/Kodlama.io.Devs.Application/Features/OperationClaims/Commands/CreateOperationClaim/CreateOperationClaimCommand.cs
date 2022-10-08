using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.DTOs;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kodlama.io.Devs.Application.Constants.ClaimConstant;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    
    public class CreateOperationClaimCommand : IRequest<CreateOperationClaimDto>,ISecuredRequest
    {
        public string Name { get; set; }


        public string[] Roles => new[] { Admin };

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreateOperationClaimDto>
        {
            #region Fields
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
            #endregion

            #region Ctor
            public CreateOperationClaimCommandHandler(
                IOperationClaimRepository operationClaimRepository,
                IMapper mapper,
                OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimBusinessRules = operationClaimBusinessRules;
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }
            #endregion
            
            #region Method
            public async Task<CreateOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);

                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);

                OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);

                CreateOperationClaimDto createdOperationClaimDto = _mapper.Map<CreateOperationClaimDto>(createdOperationClaim);

                return createdOperationClaimDto;
            }
            #endregion



        }
    }
}