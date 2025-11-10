using isc.bempleo.be.application.Interfaces.Service;
using isc.bempleo.be.application.Interfaces.Service.Knowledges;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.application.Interfaces.Service.Tools;
using isc.bempleo.be.application.Services;
using isc.bempleo.be.application.Services.Knowledges;
using isc.bempleo.be.application.Services.Profiles;
using isc.bempleo.be.application.Services.Tools;
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
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IToolService, ToolService>();
            services.AddScoped<IKnowledgeService, KnowledgeService>();

            return services;
        }
    }
}
