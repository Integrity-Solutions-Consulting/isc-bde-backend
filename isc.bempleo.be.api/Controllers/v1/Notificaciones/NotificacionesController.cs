using isc.bempleo.be.application.Interfaces.Service.NotificacionesApi;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Models.DTOs.Notificaciones;
using isc.bempleo.be.domain.Models.Response.Profiles;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace isc.bempleo.be.api.Controllers.v1.Notificaciones
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionesApiService _service;

        public NotificacionesController(INotificacionesApiService service)
        {
            _service = service;
        }

        [HttpPost("send-verification-code")]
        public async Task<IActionResult> SendVerificationCode([FromBody] NotificacionesSendVerificationCodeRequest request)
        {
            var enviado = await _service.SendVerificationCodeAsync(request);

            if (!enviado)
                return StatusCode(500, "No se pudo enviar el código de verificación.");

            return Ok("Código de verificación enviado correctamente.");
        }
    }
}
