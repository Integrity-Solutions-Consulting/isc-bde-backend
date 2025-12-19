using isc.bempleo.be.domain.Entity.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Tools
{
    public interface IToolRepository
    {
        Task<List<Tool>> GetAllToolsAsync(bool isActive, string? search = null);
        //Task<Tool> GetToolByIdAsync(int toolId);
        Task<Tool> CreateToolAsync(Tool tool);
        //Task<Tool> UpdateToolAsync(Tool tool);
        //Task<int> ActiveInactiveToolAsync(int toolId, bool status);
    }
}
