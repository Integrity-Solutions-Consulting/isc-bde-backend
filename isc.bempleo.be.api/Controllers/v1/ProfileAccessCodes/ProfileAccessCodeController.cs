using isc.bempleo.be.application.Interfaces.Service.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Request.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Response.ProfileAccessCode;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.ProfileAccessCodes
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProfileAccessCodeController : ControllerBase
    {
        private readonly IProfileAccessCodeService _service;

        public ProfileAccessCodeController(IProfileAccessCodeService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ProfileAccessCodeResponse>> Create([FromBody] ProfileAccessCodeRequest request)
        {
            var result = await _service.CreateProfileAccessCodeAsync(request);
            return Ok(result);
        }
    }
}
