using isc.bempleo.be.domain.Models.Response.ApplicationStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.ApplicationStatus
{
    public interface IApplicationStatuService
    {
        Task<List<ApplicationStatuResponse>> GetAllAsync(bool isActive);
    }
}
