using AutoMapper;
using Kodlama.io.Devs.Application.Features.Languages.DTOs;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.SoftDeleteLanguage
{
    public class SoftDeleteLanguageCommand : IRequest<SoftDeleteLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        


        public class SoftDeleteLanguageCommandHandler : IRequestHandler<SoftDeleteLanguageCommand, SoftDeleteLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public SoftDeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteLanguageDto> Handle(SoftDeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                Language mappedLanguage = _mapper.Map<Language>(request);
                mappedLanguage.IsActive = false;
                Language softDeleteLanguage = await _languageRepository.UpdateAsync(mappedLanguage);
                SoftDeleteLanguageDto  softDeleteLanguageDto = _mapper.Map<SoftDeleteLanguageDto>(softDeleteLanguage);
                return softDeleteLanguageDto;

            }
        }
    }
}
