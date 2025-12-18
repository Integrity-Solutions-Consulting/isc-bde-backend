using isc.bempleo.be.domain.Entity.Certifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Certifications
{
    public interface ICertificationRepository
    {
        Task<List<Certification>> GetAllCertificationsAsync(bool isActive, string? search = null);
        //Task<Certification?> GetCertificationByIdAsync(int certificationId);
        Task<Certification> CreateCertificationAsync(Certification certification);
        //Task<Certification> UpdateCertificationAsync(Certification certification);
        //Task<int> ActiveInactiveCertificationAsync(int certificationId, bool status);
    }
}
