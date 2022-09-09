using AutoMapper;
using Kodlama.io.Devs.Application.Features.Frameworks.DTOs;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Commands.UpdateFramework
{
    public class UpdateFrameworkCommand : IRequest<UpdateFrameworkDto>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public class UpdateFrameworkCommandHandler : IRequestHandler<UpdateFrameworkCommand, UpdateFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;

            public UpdateFrameworkCommandHandler(IFrameworkRepository frameworkRepository,IMapper mapper)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
            }
            

            public async Task<UpdateFrameworkDto> Handle(UpdateFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework mappedFramework = _mapper.Map<Framework>(request);
                Framework updatedFramework = await _frameworkRepository.UpdateAsync(mappedFramework);
                UpdateFrameworkDto updatedFrameworkDto = _mapper.Map<UpdateFrameworkDto>(updatedFramework);
                return updatedFrameworkDto;
            }
        }
    }
}
