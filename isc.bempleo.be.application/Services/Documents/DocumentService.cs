using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.application.Interfaces.Service.Documents;
using isc.bempleo.be.domain.Entity.Documents;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Request.Documents;
using isc.bempleo.be.domain.Models.Response.Documents;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;
        private readonly IMapper _mapper;

        public DocumentService(IDocumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DocumentResponse>> GetAllDocumentsAsync(bool isActive)
        {
            var allDocuments = await _repository.GetAllDocumentsAsync(isActive);

            if (allDocuments == null)
                throw new ServerFaultException("Error al obtener los documentos (resultado null).");

            if (!allDocuments.Any())
                return new List<DocumentResponse>();

            return _mapper.Map<List<DocumentResponse>>(allDocuments);
        }

    }
}
