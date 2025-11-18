using isc.bempleo.be.application.Interfaces.Repository.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Service.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Service.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Models.DTOs.Notificaciones;
using isc.bempleo.be.domain.Models.Request.ProfileAccessCodes;
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
        private readonly IProfileAccessCodeService _profileAccessCodeService;

        public NotificacionesApiService(INotificacionesApiRepository notificacionesApiRepository, IProfileService profileService, IProfileAccessCodeService profileAccessCodeService)
        {
            _notificacionesApiRepository = notificacionesApiRepository;
            _profileService = profileService;
            _profileAccessCodeService = profileAccessCodeService;
        }
        public async Task<bool> SendVerificationCodeAsync(string cedula, string email)
        {
            // Traer perfil
            //var profile = await _profileService.GetProfileByCedulaEmail(cedula, email);
            var profile = await _profileService.GetProfileByCodeAsync(cedula, email, "");

            if (profile == null)
                throw new Exception("No se encontró el perfil.");

            // Traer código de acceso generado
            var accessCode = await _profileAccessCodeService.CreateProfileAccessCodeAsync(new ProfileAccessCodeRequest
            {
                Code = "", // El código se generará en el servicio
            });

            // Llenar request para la API externa
            var request = new NotificacionesSendVerificationCodeRequest
            {
                To = profile.Email,                       // correo del perfil
                Username = $"{profile.FirstName} {profile.LastName}", // nombre del perfil
                Subject = $"Tu código de verificación",   // mensaje fijo o personalizado
                Code = accessCode.Code                     // código generado por tu servicio interno
            };

            // Llamar al endpoint externo
            return await _notificacionesApiRepository.SendVerificationCodeAsync(request);
        }


    }
}
