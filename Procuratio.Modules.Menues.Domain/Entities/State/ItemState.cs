using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ItemState
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public List<Item> Item { get; set; }
    }
}
