using isc.bempleo.be.application.Interfaces.Repository.Certifications;
using isc.bempleo.be.domain.Entity.Certifications;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace isc.bempleo.be.infrastructure.Repositories.Certifications
{
    public class CertificationRepository : ICertificationRepository
    {
        private readonly DBContext _dbContext;

        public CertificationRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Certification>> GetAllCertificationsAsync(bool isActive, string? search)
        {
            var query = _dbContext.Certifications
                .AsQueryable()
                .Where(c => c.Status == isActive);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var normalized = search.Trim().ToLowerInvariant();
                query = query.Where(c =>
                    c.CertificationName != null &&
                    c.CertificationName.ToLower().Contains(normalized));
            }

            query = query.OrderBy(c => c.CertificationName);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Certification?> GetCertificationByIdAsync(int certificationId)
        {
            return await _dbContext.Certifications
                .FirstOrDefaultAsync(c => c.Id == certificationId);
        }

        public async Task<Certification> CreateCertificationAsync(Certification certification)
        {
            await _dbContext.Certifications.AddAsync(certification);
            await _dbContext.SaveChangesAsync();
            return certification;
        }

        public async Task<Certification> UpdateCertificationAsync(Certification certification)
        {
            _dbContext.Entry(certification).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return certification;
        }

        public async Task<int> ActiveInactiveCertificationAsync(int certificationId, bool status)
        {
            return await _dbContext.Certifications
                .Where(c => c.Id == certificationId)
                .ExecuteUpdateAsync(update => update.SetProperty(c => c.Status, status));
        }
    }
}
