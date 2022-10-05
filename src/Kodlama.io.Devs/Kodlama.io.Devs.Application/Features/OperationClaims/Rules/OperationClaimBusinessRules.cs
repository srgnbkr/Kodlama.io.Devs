using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        #region Fields
        private readonly IOperationClaimRepository _operationClaimRepository;
        #endregion

        #region Constructors
        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }
        #endregion

        #region Methods
       
        public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any()) throw new BusinessException("Operation claim name exists.");
        }
        #endregion
    }
}
