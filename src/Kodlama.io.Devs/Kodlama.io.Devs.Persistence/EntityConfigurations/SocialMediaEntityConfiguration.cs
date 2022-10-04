using Core.Security.Entities;
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
    public class SocialMediaEntityConfiguration : BaseEntityConfiguration<SocialMedia>
    {
        public override void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            base.Configure(builder);
            builder.ToTable("SocialMedias", BaseDbContext.DEFAULT_SCHEMA);
            
            builder.HasOne(m => m.User)
                .WithMany(m => m.SocialMedias)
                .HasForeignKey(m => m.UserId);
            

            
        }
    }
}
