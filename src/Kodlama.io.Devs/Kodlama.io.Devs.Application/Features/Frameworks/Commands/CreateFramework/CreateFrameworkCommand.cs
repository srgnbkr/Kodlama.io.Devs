using AutoMapper;
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
        #region Properties
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        
        #endregion




        public class CreateFrameworkCommandHandler : IRequestHandler<CreateFrameworkCommand, CreateFrameworkDto>
        {
            #region Fields
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly FrameworkBusinessRules _frameworkBusinessRules;
            #endregion

            #region Ctor
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
            #endregion

            #region Method
            /// <summary>
            /// Create Framework Command Handler
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<CreateFrameworkDto> Handle(CreateFrameworkCommand request, CancellationToken cancellationToken)
            {
                
                await _frameworkBusinessRules.FrameworkNameCanNotBeDuplicatedWhenInserted(request.Name);

                
                Framework mappedFramework = _mapper.Map<Framework>(request);
                
                Framework createFramework =  await _frameworkRepository.AddAsync(mappedFramework);
               
                CreateFrameworkDto createFrameworkDto = _mapper.Map<CreateFrameworkDto>(createFramework);
                return createFrameworkDto;
            }

            #endregion
        }

    }
}
