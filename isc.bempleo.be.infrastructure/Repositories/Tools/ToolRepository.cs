using isc.bempleo.be.application.Interfaces.Repository.Tools;
using isc.bempleo.be.domain.Entity.Tools;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Tools
{
    public class ToolRepository : IToolRepository
    {
        private readonly DBContext _dbContext;

        public ToolRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Tool>> GetAllToolsAsync(bool isActive, string? search)
        {
            try
            {
                var query = _dbContext.Tools
                    .Where(t => t.Status == isActive);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var normalized = search.Trim().ToLowerInvariant();
                    query = query.Where(t =>
                        t.ToolName != null &&
                        t.ToolName.ToLower().Contains(normalized));
                }

                return await query
                    .OrderBy(t => t.ToolName)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Tools.",
                    500,
                    ex
                );
            }
        }

        //public async Task<Tool> GetToolByIdAsync(int toolId)
        //{
        //    return await _dbContext.Tools
        //        .FirstOrDefaultAsync(t => t.Id == toolId);
        //}

        public async Task<Tool> CreateToolAsync(Tool tool)
        {
            try
            {
                await _dbContext.Tools.AddAsync(tool);
                await _dbContext.SaveChangesAsync();
                return tool;
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al crear Tool.",
                    500,
                    ex
                );
            }
        }

        //public async Task<Tool> UpdateToolAsync(Tool tool)
        //{
        //    _dbContext.Entry(tool).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //    return tool;
        //}

        //public async Task<int> ActiveInactiveToolAsync(int toolId, bool status)
        //{
        //    return await _dbContext.Tools
        //        .Where(t => t.Id == toolId)
        //        .ExecuteUpdateAsync(update => update.SetProperty(t => t.Status, status));
        //}
    }
}
