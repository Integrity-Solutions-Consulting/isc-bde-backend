using isc.bempleo.be.domain.Models.DTOs.Notificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.NotificacionesApi
{
    public interface INotificacionesApiRepository
    {
        Task<bool> SendVerificationCodeAsync(NotificacionesSendVerificationCodeRequest request);
    }
}
