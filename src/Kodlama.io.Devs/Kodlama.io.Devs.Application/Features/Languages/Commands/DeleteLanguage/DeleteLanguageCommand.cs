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

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeleteLanguageDto>
    {
        public int Id { get; set; }


        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeleteLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public DeleteLanguageCommandHandler(ILanguageRepository languageRepository,IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }
            
            public async Task<DeleteLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                Language mappedLanguage = _mapper.Map<Language>(request);
                Language deletedLanguage = await _languageRepository.DeleteAsync(mappedLanguage);
                DeleteLanguageDto deleteLanguageDto = _mapper.Map<DeleteLanguageDto>(deletedLanguage);
                return deleteLanguageDto;
            }
        }
    }
}
