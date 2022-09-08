using Core.Security.Entities;
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
    public class RefreshTokenEntityConfiguration : BaseEntityConfiguration<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            base.Configure(builder);
            builder.ToTable("RefreshTokens", BaseDbContext.DEFAULT_SCHEMA);

            builder.HasOne(u => u.User).WithMany(u => u.RefreshTokens).HasForeignKey(u => u.UserId);
        }
    }
}
