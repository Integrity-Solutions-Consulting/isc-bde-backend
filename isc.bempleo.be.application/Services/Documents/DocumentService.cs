using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.application.Interfaces.Service.Documents;
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



        public DocumentService(IDocumentRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<DocumentResponse>> GetAllAsync(DocumentRequest request)
        {
            var list = await _repository.GetAllAsync();
            if(list == null || !list.Any())
            {
                return new List<DocumentResponse>();
            }

            return list;

        }
     

        
    }
}
