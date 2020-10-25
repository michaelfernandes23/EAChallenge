using EAChallenge.Domain.Interfaces;
using EAChallenge.Infrastructure;
using EAChallenge.Infrastructure.Repositories;
using EAChallenge.Services;
using EAChallenge.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAChallenge.API
{
    public static class DependencyConfig
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICarDetailsRepository, CarDetailsRepository>();
        }

        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICarDetailsService, CarDetailsService>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DotNetCoreConnection");
            
            services.AddDbContext<EAChallengeDBContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(connectionString,
                                     sqlServerOptions =>
                                     {
                                         sqlServerOptions.CommandTimeout(90);
                                     });
            });
        }
    }
}
