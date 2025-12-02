using isc.bempleo.be.application.Interfaces.Repository.Tools;
using isc.bempleo.be.domain.Entity.Tools;
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
            var query = _dbContext.Tools
                .AsQueryable()
                .Where(t => t.Status == isActive);

            if (!string.IsNullOrWhiteSpace(search))
            {
                string normalizedSearch = search.Trim().ToLowerInvariant();

                query = query.Where(t =>
                    (t.ToolName != null && t.ToolName.ToLower().Contains(normalizedSearch))
                );
            }

            query = query
                .OrderBy(t => t.ToolName);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Tool> GetToolByIdAsync(int toolId)
        {
            return await _dbContext.Tools
                .FirstOrDefaultAsync(t => t.Id == toolId);
        }

        public async Task<Tool> CreateToolAsync(Tool tool)
        {
            await _dbContext.Tools.AddAsync(tool);
            await _dbContext.SaveChangesAsync();
            return tool;
        }

        public async Task<Tool> UpdateToolAsync(Tool tool)
        {
            _dbContext.Entry(tool).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return tool;
        }

        public async Task<int> ActiveInactiveToolAsync(int toolId, bool status)
        {
            return await _dbContext.Tools
                .Where(t => t.Id == toolId)
                .ExecuteUpdateAsync(update => update.SetProperty(t => t.Status, status));
        }
    }
}
