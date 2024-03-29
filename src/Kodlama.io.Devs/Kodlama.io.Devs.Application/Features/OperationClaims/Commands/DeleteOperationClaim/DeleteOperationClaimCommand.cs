﻿using AutoMapper;
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

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<DeleteOperationClaimDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { Admin };

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeleteOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<DeleteOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {

                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(mappedOperationClaim);
                DeleteOperationClaimDto deleteOperationClaimDto = _mapper.Map<DeleteOperationClaimDto>(deletedOperationClaim);
                return deleteOperationClaimDto;
            }
        }
    }
}
