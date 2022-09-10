using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.SocialMedias.DTOs;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand : IRequest<UpdateSocialMediaDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public bool IsActive { get; set; }

        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdateSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;

            public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _mapper = mapper;
                _socialMediaRepository = socialMediaRepository;
            }


            public async Task<UpdateSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                SocialMedia updatedSocialMedia = await _socialMediaRepository.UpdateAsync(mappedSocialMedia);
                UpdateSocialMediaDto updateSocialMediaDto = _mapper.Map<UpdateSocialMediaDto>(updatedSocialMedia);
                return updateSocialMediaDto;
            }
        }
    }
}
