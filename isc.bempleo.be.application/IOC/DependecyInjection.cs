using isc.bempleo.be.application.Interfaces.Service.Booklets;
using isc.bempleo.be.application.Interfaces.Service.Catalogs;
using isc.bempleo.be.application.Interfaces.Service.Documents;
using isc.bempleo.be.application.Interfaces.Service.Experiences;
using isc.bempleo.be.application.Interfaces.Service.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.application.Interfaces.Service.ProfileVacancies;
using isc.bempleo.be.application.Interfaces.Service.S3Minio;
using isc.bempleo.be.application.Services.Booklets;
using isc.bempleo.be.application.Services.Catalogs;
using isc.bempleo.be.application.Services.Documents;
using isc.bempleo.be.application.Services.Experiences;
using isc.bempleo.be.application.Services.NotificacionesApi;
using isc.bempleo.be.application.Services.Profiles;
using isc.bempleo.be.application.Services.ProfileVacancies;
using isc.bempleo.be.application.Services.S3Minio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace isc.bempleo.be.application.IOC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<INotificacionesApiService, NotificacionesApiService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IProfileVacancyService, ProfileVacancyService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IS3MinioService, S3MinioService>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IBookletService, BookletService>();

            return services;
        }
    }
}
