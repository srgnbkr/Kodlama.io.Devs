using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Framework : Entity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }

        public Framework()
        {

        }

        public Framework(int id, int languageId, string name, string imageUrl, bool isActive) : this()
        {
            Id = id;
            LanguageId = languageId;
            Name = name;
            ImageUrl = imageUrl;
            
        }


        
    }
}
