using isc.bempleo.be.domain.Models.Request.Tools;
using isc.bempleo.be.domain.Models.Response.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Tools
{
    public interface IToolService
    {
        Task<List<ToolResponse>> GetAllToolsAsync(bool isActive, string? search = null);
        //Task<ToolResponse> GetToolById(int toolId);
        Task<ToolResponse> CreateToolAsync(ToolRequest request);
        //Task<ToolResponse> UpdateToolAsync(int toolId, ToolRequest request);
        //Task<int> ActiveInactiveToolAsync(int toolId, bool status);

    }
}
