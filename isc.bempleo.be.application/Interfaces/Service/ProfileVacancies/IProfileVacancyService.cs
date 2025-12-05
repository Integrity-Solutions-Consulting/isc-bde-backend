using isc.bempleo.be.domain.Models.Request.ProfileVacancies;
using isc.bempleo.be.domain.Models.Response.ProfileVacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.ProfileVacancies
{
    public interface IProfileVacancyService
    {
        Task<List<ProfileVacancyResponse>> GetAllAsync(bool isActive);
        Task<ProfileVacancyResponse> CreateAsync(ProfileVacancyRequest request);

    }
}
