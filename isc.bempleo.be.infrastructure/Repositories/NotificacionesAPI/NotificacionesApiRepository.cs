using isc.bempleo.be.application.Interfaces.Repository.NotificacionesApi;
using isc.bempleo.be.domain.Models.DTOs.Notificaciones;
using isc.bempleo.be.domain.Models.Response.Notifications;
using isc.bempleo.be.infrastructure.Utils.Peticiones;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.NotificacionesAPI
{
    public class NotificacionesApiRepository : INotificacionesApiRepository
    {
        private readonly HttpUtils _httpUtils;
        private readonly IConfiguration _configuration;
        
        public NotificacionesApiRepository(HttpUtils httpUtils, IConfiguration configuration)
        {
            _httpUtils = httpUtils;
            _configuration = configuration;
        }

        public async Task<NotificacionApiResponse> SendVerificationCodeAsync(NotificacionesSendVerificationCodeRequest request)
        {
            var url = $"{_configuration["Infrastructure:UrlApiBempleo"]}/send-verification-code";
            var result = await _httpUtils.SendRequest<NotificacionApiResponse>(url, HttpMethod.Post, request);

            return result ;
        }



    }
}
