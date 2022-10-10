using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.DTOs;
using Kodlama.io.Devs.Application.Services.Repositories;
using static Kodlama.io.Devs.Application.Constants.ClaimConstant;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<UpdateOperationClaimDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles => new[] { Admin };

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdateOperationClaimDto>
        {
            #region Fields
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            #endregion

            #region Ctor
            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository,IMapper mapper)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
            }
            #endregion

            #region Method
            public async Task<UpdateOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
                UpdateOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdateOperationClaimDto>(updatedOperationClaim);
                return updatedOperationClaimDto;
            }
            #endregion
        }
    }
}
