using isc.bempleo.be.domain.Entity.Experiences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Experiences
{
    public interface IExperienceRepository
    {
        Task<List<Experience>> GetAllExperiencesAsync(int profileId, bool isActive, string? search);
        Task<Experience> CreateExperienceAsync(Experience experience);
        //Task<Experience> UpdateExperienceAsync(Experience experience);
        //Task<int> ActiveInactiveExperienceAsync(int experienceId, bool status);

    }
}
