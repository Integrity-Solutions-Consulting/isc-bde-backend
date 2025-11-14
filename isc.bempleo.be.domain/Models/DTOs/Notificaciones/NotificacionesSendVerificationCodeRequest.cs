using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.DTOs.Notificaciones
{
    public class NotificacionesSendVerificationCodeRequest  
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Username { get; set; }
        public string Code { get; set; }
    }
}
