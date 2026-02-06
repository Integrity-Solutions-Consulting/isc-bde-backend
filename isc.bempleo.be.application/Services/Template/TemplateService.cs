using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Booklets;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Service.Booklets;
using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;
using isc.bempleo.be.domain.Models.Response.Template;
using System.Text.Json;

namespace isc.bempleo.be.application.Services.Booklets
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _bookletRepository;
        private readonly IMapper _mapper;

        public TemplateService(ITemplateRepository bookletRepository, IMapper mapper)
        {
            _bookletRepository = bookletRepository;
            _mapper = mapper;
        }

        public async Task<List<TemplateResponse>> GetBooklet()
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

        public async Task<TemplateDetailResponse> GetTemplateById(int id)
        {
            var booklet = await _bookletRepository.GetTemplateByIdAsync(id);

            if (booklet == null)
            {
                throw new ServerFaultException(
                    $"La plantilla con el ID {id} no fue encontrada."
                );
            }

            return booklet;
        }

        public async Task<TemplateCreateResponse> CreateTemplate(TemplateRequest request)
        {
            string jsonKnowledge = JsonSerializer.Serialize(request.KnowledgeIds);
            string jsonTools = JsonSerializer.Serialize(request.ToolIds);

            return await _bookletRepository.CreateTemplateAsync(
                request.TemplateName,
                jsonKnowledge,
                jsonTools
            );
        }


    }
}
