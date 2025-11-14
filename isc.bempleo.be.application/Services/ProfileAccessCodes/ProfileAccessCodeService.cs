using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Service.ProfileAccessCodes;
using isc.bempleo.be.domain.Entity.Knowledges;
using isc.bempleo.be.domain.Entity.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Request.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Response.Knowledges;
using isc.bempleo.be.domain.Models.Response.ProfileAccessCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.ProfileAccessCodes
{
    public class ProfileAccessCodeService : IProfileAccessCodeService
    {

        private readonly IProfileAccessCodeRepository _repo;
        private readonly IMapper _mapper;

        public ProfileAccessCodeService(
            IProfileAccessCodeRepository repository,
            IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async Task<ProfileAccessCodeResponse> CreateProfileAccessCodeAsync(ProfileAccessCodeRequest request)
        {
            // 1. Generar código único de 6 dígitos
            var code = await GenerateUniqueCodeAsync();

            // 2. Asignarlo al request (si el DTO lo tiene)
            request.Code = code;

            // 3. Mapear y guardar
            var entity = _mapper.Map<ProfileAccessCode>(request);
            entity.Code = code; // por si acaso, lo seteamos directo también

            var created = await _repo.CreateProfileAccessCodeAsync(entity);
            return _mapper.Map<ProfileAccessCodeResponse>(created);
        }

        private async Task<string> GenerateUniqueCodeAsync()
        {
            const int maxAttempts = 10;

            for (int i = 0; i < maxAttempts; i++)
            {
                // Genera un número entre 000000 y 999999
                var number = RandomNumberGenerator.GetInt32(0, 1_000_000);
                var code = number.ToString("D6"); // siempre 6 dígitos, con ceros a la izquierda

                var exists = await _repo.CodeExistsAsync(code);
                if (!exists)
                    return code;
            }

            throw new InvalidOperationException("No se pudo generar un código único después de varios intentos.");
        }


    }
}
