using isc.bempleo.be.application.Interfaces.Repository.Genders;
using isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Repository.Skills;
using isc.bempleo.be.application.Interfaces.Service;
using isc.bempleo.be.application.Interfaces.Service.Certifications;
using isc.bempleo.be.application.Interfaces.Service.Experiences;
using isc.bempleo.be.application.Interfaces.Service.Genders;
using isc.bempleo.be.application.Interfaces.Service.Knowledges;
using isc.bempleo.be.application.Interfaces.Service.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Service.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.application.Interfaces.Service.S3Minio;
using isc.bempleo.be.application.Interfaces.Service.Skills;
using isc.bempleo.be.application.Interfaces.Service.Tools;
using isc.bempleo.be.application.Services;
using isc.bempleo.be.application.Services.Certifications;
using isc.bempleo.be.application.Services.Experiences;
using isc.bempleo.be.application.Services.Genders;
using isc.bempleo.be.application.Services.Knowledges;
using isc.bempleo.be.application.Services.NotificacionesApi;
using isc.bempleo.be.application.Services.ProfileAccessCodes;
using isc.bempleo.be.application.Services.Profiles;
using isc.bempleo.be.application.Services.S3Minio;
using isc.bempleo.be.application.Services.Skills;
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

            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IToolService, ToolService>();
            services.AddScoped<IKnowledgeService, KnowledgeService>();
            services.AddScoped<IProfileAccessCodeService, ProfileAccessCodeService>();
            services.AddScoped<INotificacionesApiService, NotificacionesApiService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICertificationService, CertificationService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IGenderService, GenderService>();

            services.AddScoped<IS3MinioService, S3MinioService>();


            return services;
        }
    }
}
