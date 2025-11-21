using isc.bempleo.be.domain.Models.Request.Certifications;
using isc.bempleo.be.domain.Models.Response.Certifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Certifications
{
    public interface ICertificationService
    {
        Task<List<CertificationResponse>> GetAllCertificationsAsync(bool isActive, string? search = null);
        Task<CertificationResponse> GetCertificationByIdAsync(int certificationId);
        Task<CertificationResponse> CreateCertificationAsync(CertificationRequest request);
        Task<CertificationResponse> UpdateCertificationAsync(int certificationId, CertificationRequest request);
        Task<int> ActiveInactiveCertificationAsync(int certificationId, bool status);
    }
}
