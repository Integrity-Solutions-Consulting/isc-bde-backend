using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Service.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Entity.ProfileAccessCodes;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.DTOs.Notificaciones;
using isc.bempleo.be.domain.Models.Request.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Response.Notifications;
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
        private readonly IProfileAccessCodeRepository _profileAccessCodeRepository;
        private readonly IProfileRepository _profileRepo;
        private readonly IMapper _mapper;

        public NotificacionesApiService(INotificacionesApiRepository notificacionesApiRepository, IProfileService profileService, IProfileAccessCodeRepository profileAccessCodeRepository, IProfileRepository profileRepo, IMapper mapper)
        {
            _notificacionesApiRepository = notificacionesApiRepository;
            _profileRepo = profileRepo;
            _profileAccessCodeRepository = profileAccessCodeRepository;
            _mapper = mapper;

        }
        public async Task<NotificacionApiResponse> SendVerificationCodeAsync(string cedula, string email)
        {
            var profile = await _profileRepo.GetProfileByCedulaEmailAsync(cedula, email);

            if (profile == null)
                throw new ClientFaultException("No se encontró el perfil.");



            var request = new NotificacionesSendVerificationCodeRequest
            {
                To = profile.Email,                       
                Username = $"{profile.FirstName} {profile.LastName}", 
                Subject = $"Tu código de verificación",   
            };

            var sendMail =  await _notificacionesApiRepository.SendVerificationCodeAsync(request);




            ProfileAccessCodeRequest profileCode = new ProfileAccessCodeRequest()
            {
                Code = sendMail.Code
            };

            ProfileAccessCode entityProfileCode = _mapper.Map<ProfileAccessCode>(profileCode);


            var saveCode = await _profileAccessCodeRepository.CreateProfileAccessCodeAsync(entityProfileCode);


            return sendMail;



        }


    }
}
