using isc.bempleo.be.domain.Entity.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Skills
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllSkillsAsync(bool isActive, string? search = null);
        //Task<Skill> GetSkillByIdAsync(int skillId);
        Task<Skill> CreateSkillAsync(Skill skill);
        //Task<Skill> UpdateSkillAsync(Skill skill);
        //Task<int> ActiveInactiveSkillAsync(int skillId, bool status);
    }
}
