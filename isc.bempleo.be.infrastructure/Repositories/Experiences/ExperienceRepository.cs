using isc.bempleo.be.application.Interfaces.Repository.Experiences;
using isc.bempleo.be.domain.Entity.Experiences;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Experiences
{
    public class ExperienceRepository : IExperienceRepository
    {

        private readonly DBContext _dbContext;

        public ExperienceRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Experience>> GetAllExperiencesAsync(bool isActive, int? profileId = null, string? search = null)
        {
            var query = _dbContext.Experiences
                .AsQueryable()
                .Where(e => e.Status == isActive);

            if (profileId.HasValue)
            {
                query = query.Where(e => e.ProfileId == profileId.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var normalizedSearch = search.Trim().ToLowerInvariant();

                query = query.Where(e =>
                       (e.CompanyName != null && e.CompanyName.ToLower().Contains(normalizedSearch))
                    || (e.PositionHeld != null && e.PositionHeld.ToLower().Contains(normalizedSearch))
                );
            }

            query = query
                .OrderByDescending(e => e.CreationDate);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Experience?> GetExperienceByIdAsync(int experienceId)
        {
            return await _dbContext.Experiences
                .FirstOrDefaultAsync(e => e.Id == experienceId);
        }

        public async Task<Experience> CreateExperienceAsync(Experience experience)
        {
            await _dbContext.Experiences.AddAsync(experience);
            await _dbContext.SaveChangesAsync();
            return experience;
        }

        public async Task<Experience> UpdateExperienceAsync(Experience experience)
        {
            _dbContext.Entry(experience).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return experience;
        }

        public async Task<int> ActiveInactiveExperienceAsync(int experienceId, bool status)
        {
            return await _dbContext.Experiences
                .Where(e => e.Id == experienceId)
                .ExecuteUpdateAsync(update => update.SetProperty(e => e.Status, status));
        }

    }
}
