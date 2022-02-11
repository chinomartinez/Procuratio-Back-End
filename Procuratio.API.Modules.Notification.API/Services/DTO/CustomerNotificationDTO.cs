using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Notification.API.Services.DTO
{
    public class CustomerNotificationDTO
    {
        public string Message { get; set; }

        public bool Seen { get; set; } = false;
    }
}
