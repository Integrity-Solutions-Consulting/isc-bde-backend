using isc.bempleo.be.domain.Models.Request.Contacts;
using isc.bempleo.be.domain.Models.Request.Profiles;
using isc.bempleo.be.domain.Models.Response.Contacts;
using isc.bempleo.be.domain.Models.Response.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Contacts
{
    public interface IContactService
    {
        Task<ContactResponse> CreateContact(ContactRequest request);
        Task<List<ContactResponse>> GetContactsByClientId(int clientId);
    }
}
