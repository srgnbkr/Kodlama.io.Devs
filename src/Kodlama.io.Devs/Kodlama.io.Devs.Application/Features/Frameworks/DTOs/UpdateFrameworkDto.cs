using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.DTOs
{
    public class UpdateFrameworkDto
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        
    }
}
