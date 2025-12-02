using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Certifications;
using isc.bempleo.be.application.Interfaces.Service.Certifications;
using isc.bempleo.be.domain.Entity.Certifications;
using isc.bempleo.be.domain.Models.Request.Certifications;
using isc.bempleo.be.domain.Models.Response.Certifications;

namespace isc.bempleo.be.application.Services.Certifications
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _certificationRepository;
        private readonly IMapper _mapper;

        public CertificationService(
            ICertificationRepository certificationRepository,
            IMapper mapper)
        {
            _certificationRepository = certificationRepository;
            _mapper = mapper;
        }

        public async Task<List<CertificationResponse>> GetAllCertificationsAsync(bool isActive, string? search)
        {
            var entities = await _certificationRepository.GetAllCertificationsAsync(isActive, search);
            return _mapper.Map<List<CertificationResponse>>(entities);
        }

        public async Task<CertificationResponse> GetCertificationByIdAsync(int certificationId)
        {
            var entity = await _certificationRepository.GetCertificationByIdAsync(certificationId);
            if (entity == null)
                throw new Exception("No existe ninguna certificación con ese ID");

            return _mapper.Map<CertificationResponse>(entity);
        }

        public async Task<CertificationResponse> CreateCertificationAsync(CertificationRequest request)
        {
            var entity = _mapper.Map<Certification>(request);
            var created = await _certificationRepository.CreateCertificationAsync(entity);
            return _mapper.Map<CertificationResponse>(created);
        }

        public async Task<CertificationResponse> UpdateCertificationAsync(int certificationId, CertificationRequest request)
        {
            var entity = _mapper.Map<Certification>(request);
            entity.Id = certificationId;

            var updated = await _certificationRepository.UpdateCertificationAsync(entity);
            return _mapper.Map<CertificationResponse>(updated);
        }

        public async Task<int> ActiveInactiveCertificationAsync(int certificationId, bool status)
        {
            return await _certificationRepository.ActiveInactiveCertificationAsync(certificationId, status);
        }
    }
}
