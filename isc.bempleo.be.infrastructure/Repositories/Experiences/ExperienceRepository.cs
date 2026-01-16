using isc.bempleo.be.application.Interfaces.Repository.Experiences;
using isc.bempleo.be.domain.Entity.Experiences;
using isc.bempleo.be.domain.Exceptions;
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

        public async Task<List<Experience>> GetAllExperiencesAsync(int profileId, bool isActive, string? search)
        {
            var normalizedSearch = search?.Trim().ToLowerInvariant();

            return await _dbContext.Experiences
                .AsNoTracking()
                .Where(e => e.Status == isActive && e.ProfileId == profileId)
                .Where(e => string.IsNullOrWhiteSpace(normalizedSearch) ||
                            (e.CompanyName != null && e.CompanyName.ToLower().Contains(normalizedSearch)) ||
                            (e.PositionHeld != null && e.PositionHeld.ToLower().Contains(normalizedSearch)))
                .OrderByDescending(e => e.CreationDate)
                .ToListAsync();
        }

        public async Task<Experience> CreateExperienceAsync(Experience experience)
        {
            await _dbContext.Experiences.AddAsync(experience);
            await _dbContext.SaveChangesAsync();
            return experience;
        }

        //public async Task<Experience> UpdateExperienceAsync(Experience experience)
        //{
        //    _dbContext.Entry(experience).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //    return experience;
        //}

        //public async Task<int> ActiveInactiveExperienceAsync(int experienceId, bool status)
        //{
        //    return await _dbContext.Experiences
        //        .Where(e => e.Id == experienceId)
        //        .ExecuteUpdateAsync(update => update.SetProperty(e => e.Status, status));
        //}

    }
}
