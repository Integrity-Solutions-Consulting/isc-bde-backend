using Amazon.S3;
using isc.bempleo.be.application.Interfaces.Repository.Catalogs;
using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.application.Interfaces.Repository.Experiences;
using isc.bempleo.be.application.Interfaces.Repository.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Repository.ProfileVacancies;
using isc.bempleo.be.application.Interfaces.Repository.S3Minio;
using isc.bempleo.be.infrastructure.Database;
using isc.bempleo.be.infrastructure.Repositories.Catalogs;
using isc.bempleo.be.infrastructure.Repositories.Documents;
using isc.bempleo.be.infrastructure.Repositories.Experiences;
using isc.bempleo.be.infrastructure.Repositories.NotificacionesAPI;
using isc.bempleo.be.infrastructure.Repositories.ProfileAccessCodes;
using isc.bempleo.be.infrastructure.Repositories.Profiles;
using isc.bempleo.be.infrastructure.Repositories.ProfileVacancies;
using isc.bempleo.be.infrastructure.Repositories.S3Minio;
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

            services.AddSingleton<IAmazonS3>(sp =>
            {
                var config = new AmazonS3Config
                {
                    ServiceURL = configuration["Minio:Endpoint"],
                    ForcePathStyle = true,
                    UseHttp = true
                };

                return new AmazonS3Client(
                    configuration["Minio:AccessKey"],
                    configuration["Minio:SecretKey"],
                    config
                );
            });

            services.AddScoped<IS3NimioRepository, S3NimioRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileAccessCodeRepository, ProfileAccessCodeRepository>();
            services.AddScoped<INotificacionesApiRepository, NotificacionesApiRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();    
            services.AddScoped<IProfileVacancyRepository, ProfileVacancyRepository>();
            services.AddScoped<ICatalogRepository, CatalogRepository>();

            services.AddScoped<HttpUtils>();
                return services;
        }

        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConexionBD");

            services.AddDbContext<DBContext>(options =>
                options.UseMySql(
                        connectionString,
                        ServerVersion.AutoDetect(connectionString)
                    )
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );

            return services;
        }
    }
}
