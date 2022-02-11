using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Notification.API.Models
{
    internal class ConnectedUsers
    {
        public string ConectionId { get; set; }

        public string OrderKey { get; set; }

        public int? WaiterId { get; set; }
    }
}
