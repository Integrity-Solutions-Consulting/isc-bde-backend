using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Service.ProfileAccessCodes;
using isc.bempleo.be.domain.Entity.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Request.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Response.ProfileAccessCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.ProfileAccessCodes
{
    public class ProfileAccessCodeService : IProfileAccessCodeService
    {

        private readonly IProfileAccessCodeRepository _repository;
        private readonly IMapper _mapper;

        public ProfileAccessCodeService(
            IProfileAccessCodeRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProfileAccessCodeResponse> CreateProfileAccessCodeAsync(ProfileAccessCodeRequest request)
        {
            // Si quisieras generar el código aquí, podrías hacer:
            // var code = Guid.NewGuid().ToString("N").Substring(0, 8);

            var entity = _mapper.Map<ProfileAccessCode>(request);

            // Opcional: asegurarte de valores por defecto
            entity.Status = true;
            if (string.IsNullOrEmpty(entity.CreationUser))
                entity.CreationUser = "SYSTEM";
            if (string.IsNullOrEmpty(entity.CreationIp))
                entity.CreationIp = "0.0.0.0";

            var createdEntity = await _repository.CreateProfileAccessCodeAsync(entity);

            return _mapper.Map<ProfileAccessCodeResponse>(createdEntity);
        }

    }
}
