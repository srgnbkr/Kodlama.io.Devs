using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        /// <summary>
        /// Id'ler Ortak olduğu için  ekledim.
        /// </summary>
        /// <param name="builder"></param>
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).ValueGeneratedOnAdd();

        }
    }
}
