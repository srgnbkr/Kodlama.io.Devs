using Bogus;
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

namespace Kodlama.io.Devs.Persistence.SeedDataBogus
{
    internal class SeedData
    {
        /// <summary>
        /// Veritabanına elimizle eklemek yerine, Bogusla Fake Datalar Oluşturabiliyoruz. Basit  olalak ekledim.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public async Task SeedAsync(IConfiguration configuration)
        {

            #region Connection
            //var dbContextBuilder = new DbContextOptionsBuilder();
            //dbContextBuilder.UseSqlServer(configuration.GetConnectionString("KodlamaIOConnectionString"));

            //var context = new BaseDbContext(dbContextBuilder.Options);
            #endregion


            #region BogusExample
            //Eklentide diller olmadığı için ekleyemedim. Kullanıcı oluşturuken çok yararlı olacak :)
            //var languages = new Faker<Language>("tr")
            //    .RuleFor(i => i.Name, i => i.Commerce.Product()).Generate(10);
            #endregion


            //await context.AddRangeAsync(languages);
            //await context.SaveChangesAsync();
        }
    }
}
