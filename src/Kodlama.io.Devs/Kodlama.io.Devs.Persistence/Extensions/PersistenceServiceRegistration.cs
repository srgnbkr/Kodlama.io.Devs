﻿using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;
using Kodlama.io.Devs.Persistence.Repositories;
using Kodlama.io.Devs.Persistence.SeedDataBogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
           
            services.AddDbContext<BaseDbContext>(options =>
                                                    options.UseSqlServer(
                                                        configuration.GetConnectionString("KodlamaIOConnectionString")));

            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IFrameworkRepository,FrameworkRepository>();
            services.AddScoped<ISocialMediaRepository,SocialMediaRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();


            //Apiyi her başlattığımızda sahte data ekler.
            //var seedData = new SeedData();
            //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

            return services;
        }
    }
}
