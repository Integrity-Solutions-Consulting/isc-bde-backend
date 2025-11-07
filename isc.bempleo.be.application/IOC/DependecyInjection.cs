using isc.bempleo.be.application.Interfaces.Service;
using isc.bempleo.be.application.Services;
using isc.bempleo.be.domain.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.IOC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IProjectionService, ProjectionService>();
            return services;
        }
    }
}
