using System;
using isc.bempleo.be.domain.Entity.MaritalStatus;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.MaritalStatus
{
    public interface IMaritalStatuRepository
    {
        Task<List<MaritalStatu>> GetAllMaritalStatusAsync(bool isActive);

    }
}

