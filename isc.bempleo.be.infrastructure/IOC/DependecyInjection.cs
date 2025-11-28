using isc.bempleo.be.application.Interfaces.Repository;
using isc.bempleo.be.application.Interfaces.Repository.Certifications;
using isc.bempleo.be.application.Interfaces.Repository.Experiences;
using isc.bempleo.be.application.Interfaces.Repository.Knowledges;
using isc.bempleo.be.application.Interfaces.Repository.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Repository.Skills;
using isc.bempleo.be.application.Interfaces.Repository.Tools;
using isc.bempleo.be.infrastructure.Database;
using isc.bempleo.be.infrastructure.Repositories.Certifications;
using isc.bempleo.be.infrastructure.Repositories.Experiences;
using isc.bempleo.be.infrastructure.Repositories.Knowledges;
using isc.bempleo.be.infrastructure.Repositories.NotificacionesAPI;
using isc.bempleo.be.infrastructure.Repositories.ProfileAccessCodes;
using isc.bempleo.be.infrastructure.Repositories.Profiles;
using isc.bempleo.be.infrastructure.Repositories.Skills;
using isc.bempleo.be.infrastructure.Repositories.Tools;
using isc.bempleo.be.infrastructure.Utils.Peticiones;
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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IToolRepository, ToolRepository>();
            services.AddScoped<IKnowledgeRepository, KnowledgeRepository>();
            services.AddScoped<IProfileAccessCodeRepository, ProfileAccessCodeRepository>();
            services.AddScoped<INotificacionesApiRepository, NotificacionesApiRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ICertificationRepository, CertificationRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();

            services.AddScoped<HttpUtils>();
            return services;
        }

        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConexionBD"))
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            return services;
        }
    }
}
