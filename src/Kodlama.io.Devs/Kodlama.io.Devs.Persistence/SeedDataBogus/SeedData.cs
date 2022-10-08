using Bogus;
using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Core.Security.DTOs;
using Core.Security.Hashing;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Kodlama.io.Devs.Persistence.SeedDataBogus
{
    internal class SeedData
    {
        /// <summary>
        /// Seed data for the database
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public async Task SeedAsync(IConfiguration configuration)
        {

            #region Connection
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("KodlamaIOConnectionString"));

            var context = new BaseDbContext(dbContextBuilder.Options);
            #endregion

            

            #region BogusExample

            
            

            
            


            #endregion




            await context.AddRangeAsync();
            await context.SaveChangesAsync();

        }
    }
}
