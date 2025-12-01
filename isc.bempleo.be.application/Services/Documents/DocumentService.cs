using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.application.Interfaces.Service.Documents;
using isc.bempleo.be.domain.Entity.Documents;
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
    public class DocumentService : IDocumentsService
    {
        private readonly IDocumentRepository _repository;
        private readonly IMapper _mapper;



        public DocumentService(IDocumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<List<DocumentResponse>> GetAllDocumentsAsync()
        {
            var documents = await _repository.GetAllAsync();
            return _mapper.Map<List<DocumentResponse>>(documents);
        }

        public async Task<DocumentResponse> GetDocumentByProfileIdAsync(int profileId)
        {
            var doc = await _repository.GetByProfileId(profileId);
            if (doc == null)
                throw new Exception($"No existe ningún documento asociado al perfil {profileId}");

            return _mapper.Map<DocumentResponse>(doc);
        }

        public async Task<DocumentResponse> CreateDocumentAsync(DocumentRequest request)
        {
            var entity = _mapper.Map<Document>(request);
            var created = await _repository.CreateAsync(entity);
            return _mapper.Map<DocumentResponse>(created);
        }

        public async Task<DocumentResponse> UpdateDocumentAsync(int profileId, DocumentRequest request)
        {
            var current = await _repository.GetByProfileId(profileId);
            if (current == null)
                throw new Exception($"No existe ningún documento asociado al perfil {profileId}");

            current.ProfileId = request.ProfileId;
            current.Profile = request.Profile;
            current.Bucket = request.Bucket;
            current.ObjectName = request.ObjectName;
            current.DocumentName = request.DocumentName;

            var updated = await _repository.UpdateAsync(current);
            return _mapper.Map<DocumentResponse>(updated);
            //}



        }
    }
}
