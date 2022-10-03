using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.SocialMedias.DTOs;
using Kodlama.io.Devs.Application.Features.SocialMedias.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommand : IRequest<CreateSocialMediaDto>
    {
        
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public bool IsActive { get; set; }

        
        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreateSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public CreateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper,SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            /// <summary>
            /// Create Social Media
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<CreateSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                //Check if the user has a social media account
                await _socialMediaBusinessRules.GithubUrlCanNotBeDuplicatedWhenInserted(request.GithubUrl);

                //Create Social Media
                SocialMedia mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                //Add Social Media
                SocialMedia createSocialMedia = await _socialMediaRepository.AddAsync(mappedSocialMedia);
                //Map Social Media
                CreateSocialMediaDto createSocialMediaDto = _mapper.Map<CreateSocialMediaDto>(createSocialMedia);
                
                return createSocialMediaDto;
            }
        }
    }
}
