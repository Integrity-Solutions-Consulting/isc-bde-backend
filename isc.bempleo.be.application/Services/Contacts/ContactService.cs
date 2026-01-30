using isc.bempleo.be.application.Interfaces.Repository.Contacts;
using isc.bempleo.be.application.Interfaces.Service.Contacts;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Request.Contacts;
using isc.bempleo.be.domain.Models.Response.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Contacts
{
    public class ContactService :IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactResponse> CreateContact(ContactRequest request)
        {
            var newContact = await _contactRepository.CreateContactAsync(request);

            if (newContact == null)
            {
                throw new ServerFaultException("Error interno: La creación del contacto retornó un valor nulo.");
            }

            if (newContact.ContactID <= 0)
            {
                throw new ServerFaultException(
                    "Error al crear el contacto: No se generó un ID válido en la base de datos."
                );
            }

            return newContact;
        }

        public async Task<List<ContactResponse>> GetContactsByClientId(int clientId)
        {
           var contacts = await _contactRepository.GetContactsByClientAsync(clientId);

            if (contacts == null)
            {
                throw new ServerFaultException(
                    "Error interno: La consulta de contactos retornó un valor nulo."
                );
            }

            if (!contacts.Any())
            {
                return new List<ContactResponse>();
            }

            return contacts;
        }

    }
}
