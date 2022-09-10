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

namespace Kodlama.io.Devs.Application.Features.Frameworks.Commands.DeleteFramework
{
    public class DeleteFrameworkCommand : IRequest<DeleteFrameworkDto>
    {
        public int Id { get; set; }

        public class DeleteFrameworkCommandHandler : IRequestHandler<DeleteFrameworkCommand, DeleteFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;

            public DeleteFrameworkCommandHandler(IFrameworkRepository frameworkRepository, IMapper mapper)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
            }

            public async Task<DeleteFrameworkDto> Handle(DeleteFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework mappedFramework = _mapper.Map<Framework>(request);
                Framework deletedFramework = await _frameworkRepository.DeleteAsync(mappedFramework);
                DeleteFrameworkDto deleteFrameworkDto = _mapper.Map<DeleteFrameworkDto>(deletedFramework);
                return deleteFrameworkDto;
            }
        }
    }
}
