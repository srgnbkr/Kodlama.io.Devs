using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Rules
{
    public class SocialMediaBusinessRules
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task GithubUrlCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<SocialMedia> result = await _socialMediaRepository.GetListAsync(x => x.GithubUrl == name);
            if (result.Items.Any()) throw new BusinessException("GithubUrl  exists.");
        }
    }
}
