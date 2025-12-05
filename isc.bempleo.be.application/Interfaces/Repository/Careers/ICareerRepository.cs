using isc.bempleo.be.domain.Entity.Careers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Careers
{
    public interface ICareerRepository
    {
        Task<List<Career>> GetAllCareeraAsync(bool isActive);

    }
}
