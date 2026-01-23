using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;

namespace isc.bempleo.be.application.Interfaces.Service.Booklets
{
    public interface IBookletService
    {
        Task<List<BookletResponse>> GetBooklet();
        Task<BookletResponse> CreateBooklet(BookletRequest request);
    }
}
