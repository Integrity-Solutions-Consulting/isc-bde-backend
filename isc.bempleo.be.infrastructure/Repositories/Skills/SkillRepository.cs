using isc.bempleo.be.application.Interfaces.Repository.Skills;
using isc.bempleo.be.domain.Entity.Skills;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Skills
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DBContext _dbContext;

        public SkillRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Skill>> GetAllSkillsAsync(bool isActive, string? search)
        {
            try
            {
                var query = _dbContext.Skills
                    .Where(s => s.Status == isActive);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var normalized = search.Trim().ToLowerInvariant();
                    query = query.Where(s =>
                        s.SkillName != null &&
                        s.SkillName.ToLower().Contains(normalized));
                }

                return await query
                    .OrderBy(s => s.SkillName)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Skills.",
                    500,
                    ex
                );
            }
        }

        //public async Task<Skill> GetSkillByIdAsync(int skillId)
        //{
        //    return await _dbContext.Skills
        //        .FirstOrDefaultAsync(s => s.Id == skillId);
        //}

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            try
            {
                await _dbContext.Skills.AddAsync(skill);
                await _dbContext.SaveChangesAsync();
                return skill;
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al crear Skill.",
                    500,
                    ex
                );
            }
        }

        //public async Task<Skill> UpdateSkillAsync(Skill skill)
        //{
        //    _dbContext.Entry(skill).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //    return skill;
        //}

        //public async Task<int> ActiveInactiveSkillAsync(int skillId, bool status)
        //{
        //    return await _dbContext.Skills
        //        .Where(s => s.Id == skillId)
        //        .ExecuteUpdateAsync(update => update.SetProperty(s => s.Status, status));
        //}
    }
}
