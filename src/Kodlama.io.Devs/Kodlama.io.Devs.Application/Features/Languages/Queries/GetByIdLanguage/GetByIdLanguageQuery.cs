using AutoMapper;
using Kodlama.io.Devs.Application.Features.Languages.DTOs;
using Kodlama.io.Devs.Application.Features.Languages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery : IRequest<LanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, LanguageGetByIdDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly LanguageBusinessRules _languageBusinessRules;
            private readonly IMapper _mapper;

            public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _languageBusinessRules = languageBusinessRules;
                _mapper = mapper;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<LanguageGetByIdDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                Language language = await _languageRepository.GetAsync(x => x.Id == request.Id);

                _languageBusinessRules.LanguageShouldExistWhenRequested(language);

                LanguageGetByIdDto languageGetByIdDto = _mapper.Map<LanguageGetByIdDto>(language);

                return languageGetByIdDto;
            }
        }
    }
}
