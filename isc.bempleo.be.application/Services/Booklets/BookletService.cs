using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Booklets;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Service.Booklets;
using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;

namespace isc.bempleo.be.application.Services.Booklets
{
    public class BookletService : IBookletService
    {
        private readonly IBookletRepository _bookletRepository;
        private readonly IMapper _mapper;

        public BookletService(IBookletRepository bookletRepository, IMapper mapper)
        {
            _bookletRepository = bookletRepository;
            _mapper = mapper;
        }

        public async Task<BookletResponse> CreateBooklet(BookletRequest request)
        {
            var booklet = await _bookletRepository.CreateBookletAsync(request);

            if (booklet == null)
                throw new ClientFaultException("No existe el perfil con ese ID.");  
            
            return booklet;
        }

        public async Task<List<BookletResponse>> GetBooklet()
        {
            var booklet = await _bookletRepository.GetBookletAsync();

            if (booklet == null)
            {
                throw new ServerFaultException(
                    "Error interno: La consulta de estatus de estudio retornó un valor nulo."
                );
            }

            return booklet;
        }
    }
}
