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
    public class OperationClaimEntityConfiguration : BaseEntityConfiguration<OperationClaim>
    {
        public override void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            base.Configure(builder);
            builder.ToTable("OperationClaims", BaseDbContext.DEFAULT_SCHEMA);

            
            

        }
    }
}
