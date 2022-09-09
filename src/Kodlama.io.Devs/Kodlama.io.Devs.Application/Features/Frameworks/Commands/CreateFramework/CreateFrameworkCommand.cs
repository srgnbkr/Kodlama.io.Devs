﻿using AutoMapper;
using Kodlama.io.Devs.Application.Features.Frameworks.DTOs;
using Kodlama.io.Devs.Application.Features.Frameworks.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Commands.CreateFramework
{
    public class CreateFrameworkCommand : IRequest<CreateFrameworkDto>
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        public class CreateFrameworkCommandHandler : IRequestHandler<CreateFrameworkCommand, CreateFrameworkDto>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;

            public CreateFrameworkCommandHandler(
                IMapper mapper, 
                IFrameworkRepository frameworkRepository,
                FrameworkBusinessRules frameworkBusinessRules
                )
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
                _frameworkBusinessRules = frameworkBusinessRules;
            }

            public async Task<CreateFrameworkDto> Handle(CreateFrameworkCommand request, CancellationToken cancellationToken)
            {
                await _frameworkBusinessRules.FrameworkNameCanNotBeDuplicatedWhenInserted(request.Name);

                Framework mappedFramework = _mapper.Map<Framework>(request);
                Framework createFramework =  await _frameworkRepository.AddAsync(mappedFramework);
                CreateFrameworkDto createFrameworkDto = _mapper.Map<CreateFrameworkDto>(createFramework);
                return createFrameworkDto;
            }
        }

    }
}
