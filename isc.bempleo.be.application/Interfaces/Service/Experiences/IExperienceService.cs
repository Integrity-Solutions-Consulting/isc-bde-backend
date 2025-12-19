using isc.bempleo.be.domain.Models.Request.Experiences;
using isc.bempleo.be.domain.Models.Response.Experiences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Experiences
{
    public interface IExperienceService
    {
        Task<List<ExperienceResponse>> GetAllExperiencesAsync(int profileId, bool isActive, string? search = null);
        //Task<ExperienceResponse> GetExperienceById(int experienceId);
        Task<ExperienceResponse> CreateExperienceAsync(ExperienceRequest request);
        //Task<ExperienceResponse> UpdateExperienceAsync(int experienceId, ExperienceUpdateRequest request);
        //Task<int> ActiveInactiveExperienceAsync(int experienceId, bool status);
    }
}
