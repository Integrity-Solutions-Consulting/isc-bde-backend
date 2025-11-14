using isc.bempleo.be.application.Interfaces.Repository.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Service.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Models.DTOs.Notificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.NotificacionesApi
{
    public class NotificacionesApiService : INotificacionesApiService
    {
        private readonly INotificacionesApiRepository _notificacionesApiRepository;
        private readonly IProfileService _profileService;

        public NotificacionesApiService(INotificacionesApiRepository notificacionesApiRepository, IProfileService profileService)
        {
            _notificacionesApiRepository = notificacionesApiRepository;
            _profileService = profileService;
        }
        public async Task<bool> SendVerificationCodeAsync(NotificacionesSendVerificationCodeRequest request)
        {

            if (request == null)
                request = new NotificacionesSendVerificationCodeRequest();



            if (string.IsNullOrWhiteSpace(request.To))
                throw new ArgumentException("El correo de destino (To) es obligatorio.");

            if (string.IsNullOrWhiteSpace(request.Subject))
                throw new ArgumentException("El asunto (Subject) es obligatorio.");

            if (string.IsNullOrWhiteSpace(request.Username))
                throw new ArgumentException("El username es obligatorio.");

            if (string.IsNullOrWhiteSpace(request.Code))
                throw new ArgumentException("El código es obligatorio.");

            var mail = await _notificacionesApiRepository.SendVerificationCodeAsync(request);
            return mail;
        }

    }
}
