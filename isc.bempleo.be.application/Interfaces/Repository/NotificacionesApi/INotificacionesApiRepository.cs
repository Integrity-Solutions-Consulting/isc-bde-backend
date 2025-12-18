using isc.bempleo.be.domain.Models.DTOs.Notificaciones;
using isc.bempleo.be.domain.Models.Response.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.NotificacionesApi
{
    public interface INotificacionesApiRepository
    {
        Task<NotificacionApiResponse> SendVerificationCodeAsync(NotificacionesSendVerificationCodeRequest request);
    }
}
