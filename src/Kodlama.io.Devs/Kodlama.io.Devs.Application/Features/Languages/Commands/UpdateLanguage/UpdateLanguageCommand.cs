﻿using AutoMapper;
using Kodlama.io.Devs.Application.Features.Languages.DTOs;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<UpdateLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdateLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<UpdateLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                Language mappedLanguage = _mapper.Map<Language>(request);
                Language updatedLanguage = await _languageRepository.UpdateAsync(mappedLanguage);
                UpdateLanguageDto updatedLanguageDto = _mapper.Map<UpdateLanguageDto>(updatedLanguage);
                return updatedLanguageDto;
            }
        }
    }
}
