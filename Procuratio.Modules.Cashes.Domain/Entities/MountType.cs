using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Cashes.Domain.Entities
{
    public class MountType
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public MovementType MovementType { get; set; }

        public List<Cash> Cashes { get; set; }
    }
}
