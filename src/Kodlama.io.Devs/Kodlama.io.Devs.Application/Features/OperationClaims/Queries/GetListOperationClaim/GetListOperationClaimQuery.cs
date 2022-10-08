using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kodlama.io.Devs.Application.Constants.ClaimConstant;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }

        

        public class GetListOperationClaimHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
        {
            #region Fiedls
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            #endregion

            #region Ctor
            public GetListOperationClaimHandler(IOperationClaimRepository operationClaimRepository,IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }
            #endregion
            public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                
                IPaginate<OperationClaim> operationClaim = await _operationClaimRepository.
                    GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                
                OperationClaimListModel operationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaim);
                
                return operationClaimListModel;
            }
        }
    }
}
