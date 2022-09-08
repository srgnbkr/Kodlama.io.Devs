using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.EntityConfigurations
{
    public class FrameworkEntityConfiguration : BaseEntityConfiguration<Framework>
    {
        public override void Configure(EntityTypeBuilder<Framework> builder)
        {
            base.Configure(builder);
            builder.ToTable("Framewokrs",BaseDbContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Language)
                .WithMany(i => i.Frameworks)
                .HasForeignKey(i => i.LanguageId);
        }
    }
}
