using isc.bempleo.be.domain.Entity.ApplicationStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.ApplicationStatus
{
    public interface IApplicationStatuRepository
    {
        Task<List<ApplicationStatu>> GetAllApplicationStatusAsync(bool isActive);
    }
}
