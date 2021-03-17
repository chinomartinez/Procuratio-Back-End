using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class SubCategoryItemState
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public List<SubCategoryItem> SubCategoryItem { get; set; }

        public enum State
        {

        }
    }
}
