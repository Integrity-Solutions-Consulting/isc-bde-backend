using isc.bempleo.be.application.Interfaces.Repository.Knowledges;
using isc.bempleo.be.domain.Entity.Knowledges;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Knowledges
{
    public class KnowledgeRepository : IKnowledgeRepository
    {
        private readonly DBContext _dbContext;
        public KnowledgeRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Knowledge>> GetAllKnowledgesAsync(bool isActive, string? search = null)
        {
            var query = _dbContext.Knowledges
                .AsQueryable()
                .Where(k => k.Status == isActive);

            if (!string.IsNullOrWhiteSpace(search))
            {
                string normalizedSearch = search.Trim().ToLowerInvariant();

                query = query.Where(k =>
                    (k.KnowledgeName != null && k.KnowledgeName.ToLower().Contains(normalizedSearch)) ||
                    (k.KnowledgeType != null && k.KnowledgeType.ToLower().Contains(normalizedSearch))
                );
            }

            query = query
                .OrderBy(k => k.KnowledgeName)
                .ThenBy(k => k.KnowledgeType);

            return await query.AsNoTracking().ToListAsync();
        }


        public async Task<Knowledge> GetKnowledgeByIdAsync(int knowledgeId)
        {
            return await _dbContext.Knowledges
                .FirstOrDefaultAsync(k => k.Id == knowledgeId);
        }

        public async Task<Knowledge> CreateKnowledgeAsync(Knowledge knowledge)
        {
            await _dbContext.Knowledges.AddAsync(knowledge);
            await _dbContext.SaveChangesAsync();
            return knowledge;
        }

        public async Task<Knowledge> UpdateKnowledgeAsync(Knowledge knowledge)
        {
            _dbContext.Entry(knowledge).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return knowledge;
        }

        public async Task<int> ActiveInactiveKnowledgeAsync(int knowledgeId, bool status)
        {
            return await _dbContext.Knowledges
                .Where(k => k.Id == knowledgeId)
                .ExecuteUpdateAsync(update => update.SetProperty(k => k.Status, status));
        }
    }
}
