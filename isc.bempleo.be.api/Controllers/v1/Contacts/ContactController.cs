using isc.bempleo.be.application.Interfaces.Service.Catalogs;
using isc.bempleo.be.application.Interfaces.Service.Contacts;
using isc.bempleo.be.application.Services.Catalogs;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Request.Contacts;
using isc.bempleo.be.domain.Models.Request.Profiles;
using isc.bempleo.be.domain.Models.Response.Contacts;
using isc.bempleo.be.domain.Models.Response.Profiles;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace isc.bempleo.be.api.Controllers.v1.Contacts
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("create-contact")]
        public async Task<ActionResult<ContactResponse>>CreateContactAsync(ContactRequest request)
        {
            var response = await _contactService.CreateContact(request);
            return Ok(response);
        }

        [HttpGet("get-contact-by-client")]
        public async Task<ActionResult<List<ContactResponse>>> GetContactsByClient(int clientId)
        {
            var result = await _contactService.GetContactsByClientId(clientId);

            return Ok(result);
        }



    }
}
