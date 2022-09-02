using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Languages.DTOs
{
    public class CreateLanguageDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
