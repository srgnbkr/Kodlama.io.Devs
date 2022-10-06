using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.DTOs;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreateUserOperationClaimDto>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public bool IsActive { get; set; }

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreateUserOperationClaimDto>
        {
            #region Fields
            private readonly IMapper _mapper;
            private IUserOperationClaimRepository _userOperationClaimRepository;
            #endregion

            #region Ctor
            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,IMapper mapper)
            {
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }
            #endregion

            #region Handler
            public async Task<CreateUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                // Map request to entity
                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                // Create new user operation claim
                UserOperationClaim createUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
                // Map entity to dto
                CreateUserOperationClaimDto createUserOperationClaimDto = _mapper.Map<CreateUserOperationClaimDto>(createUserOperationClaim);

                return createUserOperationClaimDto;
            }
           
            #endregion
        }
    }
}
