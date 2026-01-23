using isc.bempleo.be.application.Interfaces.Repository.Booklets;
using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
            var result = await _dbContext
              .Set<BookletResponse>()
              .FromSqlRaw("EXEC dbo.sp_create_booklet @BookletName, @Knowledge, @Tools",
                           new SqlParameter("@BookletName", request.BookletName),
                           new SqlParameter("@Knowledge", request.Knowledge),
                           new SqlParameter("@Tools", request.Tools))
              .AsNoTracking()
              .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<BookletResponse>> GetBookletAsync()
        {
            return await _dbContext
              .Set<BookletResponse>()
              .FromSqlRaw("EXEC dbo.sp_  nombresp   ")
              .AsNoTracking()
              .ToListAsync();
        }
    }
}
