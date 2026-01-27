using isc.bempleo.be.domain.Models.Request.Contacts;
using isc.bempleo.be.domain.Models.Response.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Contacts
{
    public interface IContactRepository
    {
        Task<ContactResponse> CreateContactAsync(ContactRequest request);
        Task<List<ContactResponse>> GetContactsByClientAsync(int clientId);
    }
}
