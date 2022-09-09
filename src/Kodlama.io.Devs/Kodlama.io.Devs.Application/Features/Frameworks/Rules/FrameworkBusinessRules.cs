using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Rules
{
    public class FrameworkBusinessRules
    {
        private readonly IFrameworkRepository _frameworkRepository;

        public FrameworkBusinessRules(IFrameworkRepository frameworkRepository)
        {
            _frameworkRepository = frameworkRepository;
        }

        public async Task FrameworkNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Framework> result = await _frameworkRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any()) throw new BusinessException("Framework name exists.");

        }
    }
}
