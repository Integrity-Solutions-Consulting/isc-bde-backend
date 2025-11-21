using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Repository.Tools;
using isc.bempleo.be.application.Interfaces.Service.Tools;
using isc.bempleo.be.domain.Entity.Tools;
using isc.bempleo.be.domain.Models.Request.Tools;
using isc.bempleo.be.domain.Models.Response.Tools;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Tools
{
    public class ToolService : IToolService
    {
        private readonly IToolRepository _toolRepository;
        private readonly IMapper _mapper;

        public ToolService(IToolRepository toolRepository, IMapper mapper)
        {
            _toolRepository = toolRepository;
            _mapper = mapper;
        }

        public async Task<List<ToolResponse>> GetAllToolsAsync(bool isActive, string? search)
        {
            var allTools = await _toolRepository.GetAllToolsAsync(isActive, search);
            return _mapper.Map<List<ToolResponse>>(allTools);
        }


        public async Task<ToolResponse> GetToolById(int toolId)
        {
            var tool = await _toolRepository.GetToolByIdAsync(toolId);
            if (tool == null)
                throw new Exception("No existe ninguna herramienta con ese ID");

            return _mapper.Map<ToolResponse>(tool);
        }

        public async Task<ToolResponse> CreateToolAsync(ToolRequest request)
        {
            var entity = _mapper.Map<Tool>(request);
            var createdEntity = await _toolRepository.CreateToolAsync(entity);

            return _mapper.Map<ToolResponse>(createdEntity);
        }

        public async Task<ToolResponse> UpdateToolAsync(int toolId, ToolRequest request)
        {
            var entity = _mapper.Map<Tool>(request);
            entity.Id = toolId;

            var updatedEntity = await _toolRepository.UpdateToolAsync(entity);
            return _mapper.Map<ToolResponse>(updatedEntity);
        }

        public async Task<int> ActiveInactiveToolAsync(int toolId, bool status)
        {
            return await _toolRepository.ActiveInactiveToolAsync(toolId, status);
        }






    }
}
