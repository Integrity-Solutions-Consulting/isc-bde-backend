using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Booklets
{
    public interface IBookletRepository
    {
        Task<List<BookletResponse>> GetBookletAsync();
        Task<BookletResponse> CreateBookletAsync(BookletRequest request);
    }
}
