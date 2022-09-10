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

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommand : IRequest<DeleteSocialMediaDto>
    {
        public int Id { get; set; }

        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeleteSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;

            public DeleteSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<DeleteSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                SocialMedia deletedSocialMedia = await _socialMediaRepository.DeleteAsync(mappedSocialMedia);
                DeleteSocialMediaDto deleteSocialMediaDto = _mapper.Map<DeleteSocialMediaDto>(deletedSocialMedia);
                return deleteSocialMediaDto;
            }
        }
    }
}
