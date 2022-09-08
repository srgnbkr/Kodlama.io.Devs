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
    public class UserOperationClaimEntityConfiguration : BaseEntityConfiguration<UserOperationClaim>
    {
        public override void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            base.Configure(builder);
            builder.ToTable("UserOperationClaims", BaseDbContext.DEFAULT_SCHEMA);
            
            builder.HasOne(u => u.User).WithMany(u => u.UserOperationClaims).HasForeignKey(u => u.UserId);
            
            
            
        }
    }
}
