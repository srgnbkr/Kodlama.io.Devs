using Bogus.DataSets;
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
    public class LanguageEntityConfiguration : BaseEntityConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            base.Configure(builder);

            builder.ToTable("Languages",BaseDbContext.DEFAULT_SCHEMA);
        }
    }
}
