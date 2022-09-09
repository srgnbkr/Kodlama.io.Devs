using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Frameworks.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Queries.GetListFrameworkByDynamic
{
    public class GetListFrameworkByDynamicQuery : IRequest<FrameworkListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListFrameroksByDynamicQueryHandler : IRequestHandler<GetListFrameworkByDynamicQuery, FrameworkListModel>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public GetListFrameroksByDynamicQueryHandler(IMapper mapper,IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }
            
            public async Task<FrameworkListModel> Handle(GetListFrameworkByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Framework> frameWorks = await _frameworkRepository.GetListByDynamicAsync(request.Dynamic, 
                    include:
                    x => x.Include(a => a.Language),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );

                FrameworkListModel mappedListModel = _mapper.Map<FrameworkListModel>(frameWorks);
                return mappedListModel;
            }
        }
    }
}
