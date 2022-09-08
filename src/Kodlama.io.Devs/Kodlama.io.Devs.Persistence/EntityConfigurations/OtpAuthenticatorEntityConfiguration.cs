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
    public class OtpAuthenticatorEntityConfiguration : BaseEntityConfiguration<OtpAuthenticator>
    {
        public override void Configure(EntityTypeBuilder<OtpAuthenticator> builder)
        {
            base.Configure(builder);
            builder.ToTable("OtpAuthenticators", BaseDbContext.DEFAULT_SCHEMA);

            builder.HasOne(x => x.User);
        }
    }
}
