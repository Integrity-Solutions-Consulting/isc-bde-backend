using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Repository.Tools;
using isc.bempleo.be.application.Interfaces.Service.Tools;
using isc.bempleo.be.domain.Entity.Tools;
using isc.bempleo.be.domain.Exceptions;
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
            var tools = await _toolRepository.GetAllToolsAsync(isActive, search);

            if (tools == null)
                throw new ServerFaultException(
                    "Error al obtener las herramientas."
                );

            if (!tools.Any())
                return new List<ToolResponse>();

            return _mapper.Map<List<ToolResponse>>(tools);
        }


        //public async Task<ToolResponse> GetToolById(int toolId)
        //{
        //    var tool = await _toolRepository.GetToolByIdAsync(toolId);
        //    if (tool == null)
        //        throw new Exception("No existe ninguna herramienta con ese ID");

        //    return _mapper.Map<ToolResponse>(tool);
        //}

        public async Task<ToolResponse> CreateToolAsync(ToolRequest request)
        {
            if (request == null)
                throw new ClientFaultException(
                    "La información de la herramienta es inválida."
                );

            var entity = _mapper.Map<Tool>(request);

            var created = await _toolRepository.CreateToolAsync(entity);

            if (created == null)
                throw new ServerFaultException(
                    "Error al crear la herramienta."
                );

            return _mapper.Map<ToolResponse>(created);
        }

        //public async Task<ToolResponse> UpdateToolAsync(int toolId, ToolRequest request)
        //{
        //    var entity = _mapper.Map<Tool>(request);
        //    entity.Id = toolId;

        //    var updatedEntity = await _toolRepository.UpdateToolAsync(entity);
        //    return _mapper.Map<ToolResponse>(updatedEntity);
        //}

        //public async Task<int> ActiveInactiveToolAsync(int toolId, bool status)
        //{
        //    return await _toolRepository.ActiveInactiveToolAsync(toolId, status);
        //}






    }
}
