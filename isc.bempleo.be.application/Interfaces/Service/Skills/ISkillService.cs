using isc.bempleo.be.domain.Models.Request.Skills;
using isc.bempleo.be.domain.Models.Response.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Skills
{
    public interface ISkillService
    {
        Task<List<SkillResponse>> GetAllSkillsAsync(bool isActive, string? search = null);
        //Task<SkillResponse> GetSkillByIdAsync(int skillId);
        Task<SkillResponse> CreateSkillAsync(SkillRequest request);
        //Task<SkillResponse> UpdateSkillAsync(int skillId, SkillRequest request);
        //Task<int> ActiveInactiveSkillAsync(int skillId, bool status);
    }
}
