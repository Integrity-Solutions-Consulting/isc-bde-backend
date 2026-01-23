using isc.bempleo.be.application.Interfaces.Repository.Booklets;
using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;
using isc.bempleo.be.infrastructure.Database;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using isc.bempleo.be.domain.Models.Response.Catalogs;

namespace isc.bempleo.be.infrastructure.Repositories.Booklets
{
    public class BookletRepository : IBookletRepository
    {
        private readonly DBContext _dbContext;

        public BookletRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookletResponse> CreateBookletAsync(BookletRequest request)
        {
            var pBookletName = new MySqlParameter("@BookletName", request.BookletName);
            var pKnowledge = new MySqlParameter("@Knowledge", request.Knowledge);
            var pTools = new MySqlParameter("@Tools", request.Tools);

            var result = await _dbContext
                .Set<BookletResponse>()
                .FromSqlRaw("CALL sp_create_booklet(@BookletName, @Knowledge, @Tools)",
                            pBookletName, pKnowledge, pTools)
                .AsNoTracking()
                .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<List<BookletResponse>> GetBookletAsync()
        {
            return await _dbContext
                .Set<BookletResponse>()
                .FromSqlRaw("CALL sp_nombresp()")
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
