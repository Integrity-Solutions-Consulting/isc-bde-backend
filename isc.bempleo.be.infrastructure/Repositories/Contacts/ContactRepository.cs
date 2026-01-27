using isc.bempleo.be.application.Interfaces.Repository.Contacts;
using isc.bempleo.be.domain.Models.Request.Contacts;
using isc.bempleo.be.domain.Models.Response.Contacts;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Contacts
{
    public class ContactRepository : IContactRepository
    {

        private readonly DBContext _dbContext;

        public ContactRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContactResponse> CreateContactAsync(ContactRequest request)
        {
            var pNombre = new MySqlParameter("@p_nombre", request.ContactName);
            var pApellido = new MySqlParameter("@p_apellido", request.ContactLastName);
            var pEmail = new MySqlParameter("@p_email", request.ContactEmail);

            var resultId = await _dbContext.Database
                .SqlQueryRaw<int>("CALL SP_CreateContact(@p_nombre, @p_apellido, @p_email)", pNombre, pApellido, pEmail)
                .ToListAsync();

            int newId = resultId.FirstOrDefault();

            return new ContactResponse
            {
                ContactId = newId,
                ContactName = request.ContactName,         
                ContactLastName = request.ContactLastName, 
                ContactEmail = request.ContactEmail
            };
        }

        public async Task<List<ContactResponse>> GetContactsByClientAsync(int clientId)
        {
            var pClientId = new MySqlParameter("@p_client_id", clientId);

            return await _dbContext
                .Set<ContactResponse>()
                .FromSqlRaw("CALL SP_GetContactsByClient(@p_client_id)", pClientId)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
