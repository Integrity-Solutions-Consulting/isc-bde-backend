using isc.bempleo.be.application.Interfaces.Repository;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.infrastructure.Database;
using isc.bempleo.be.infrastructure.Repositories.Profiles;
using isc.bempleo.be.infrastructure.Repositories.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.IOC
{
    public static class DependecyInjection 
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IProjectionRepository, ProjectionRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

            return services;
        }

        public static IServiceCollection AddDbConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext> (options =>
                options.UseSqlServer(configuration.GetConnectionString("ConexionBD"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            return services;
        }
    }
}
