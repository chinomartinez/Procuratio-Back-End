using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class PromotionState
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public List<Promotion> Promotions { get; set; }

        public enum State
        {

        }
    }
}
