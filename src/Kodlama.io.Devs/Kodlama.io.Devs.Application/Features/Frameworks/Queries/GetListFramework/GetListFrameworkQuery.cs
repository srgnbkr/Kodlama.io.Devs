using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Frameworks.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Queries.GetListFramework
{
    public class GetListFrameworkQuery :  IRequest<FrameworkListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListFrameworkQueryHandler : IRequestHandler<GetListFrameworkQuery, FrameworkListModel>
        {
            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public GetListFrameworkQueryHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }

            public async Task<FrameworkListModel> Handle(GetListFrameworkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Framework> frameworks = await _frameworkRepository.GetListAsync
                    (
                    include:
                    x => x.Include(a => a.Language), 
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );

                FrameworkListModel mappedListModel = _mapper.Map<FrameworkListModel>(frameworks);
                return mappedListModel;
            }
        }
    }
}
