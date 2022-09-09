using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Frameworks.DTOs;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Models
{
    public class FrameworkListModel : BasePageableModel
    {
        public IList<FrameworkListDto> Items { get; set; }
    }
}