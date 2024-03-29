﻿using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.DTOs;
using Kodlama.io.Devs.Application.Services.Repositories;
using static Kodlama.io.Devs.Application.Constants.ClaimConstant;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Pipelines.Authorization;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommand : IRequest<UpdateUserOperationClaimDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public string[] Roles => new[] { Admin };
 
        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdateUserOperationClaimDto>
        {
            #region Fields
            private readonly IMapper _mapper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            #endregion

            #region Ctor
            public UpdateUserOperationClaimCommandHandler(IMapper mapper,IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
            
            }
            #endregion

            #region Handler
            public async Task<UpdateUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim mappedUserOperationClaim = 
                    _mapper.Map<UserOperationClaim>(request);

                UserOperationClaim updatedUserOperationClaim = 
                    await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);

                UpdateUserOperationClaimDto updateUserOperationClaimDto = 
                    _mapper.Map<UpdateUserOperationClaimDto>(updatedUserOperationClaim);

                return updateUserOperationClaimDto;
            }
            #endregion
        }

    }    
}
