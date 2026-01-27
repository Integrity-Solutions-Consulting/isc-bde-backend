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

        public async Task<int> CreateTemplate(TemplateRequest request, string currentUser, string currentIp)
        {

            // 2. PREPARACIÓN DE DATOS (Responsabilidad del Servicio)
            // Convertimos las listas a String JSON aquí
            string jsonKnowledge = JsonSerializer.Serialize(request.KnowledgeIds);
            string jsonTools = JsonSerializer.Serialize(request.ToolIds);

            // 3. Llamada al Repositorio
            // Le pasamos los strings ya procesados
            var newTemplateId = await _bookletRepository.CreateTemplateAsync(
                request.TemplateName,
                jsonKnowledge,
                jsonTools,
                currentUser,
                currentIp
            );

            return newTemplateId;
        }

    }
}
