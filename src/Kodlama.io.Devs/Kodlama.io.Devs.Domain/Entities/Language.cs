using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Language : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Framework> Frameworks {get;set;}
        public Language()
        {

        }

        public Language(int id, string name,bool isActive) : this()
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
    }
}
