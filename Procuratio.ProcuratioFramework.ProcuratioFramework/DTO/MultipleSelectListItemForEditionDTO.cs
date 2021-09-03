using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.ProcuratioFramework.DTO
{
    /// <summary>
    /// DTO to fill a multiple selection option with the selected
    /// </summary>
    /// <typeparam name="TKey">Type of key</typeparam>
    public class MultipleSelectListItemForEditionDTO<TKey>
    {
        /// <summary>
        /// List of items for load the select list item
        /// </summary>
        public List<SelectListItemDTO<TKey>> Items { get; set; } = new List<SelectListItemDTO<TKey>>();

        /// <summary>
        /// Ids of the already selected options
        /// </summary>
        public List<TKey> SelectedOptionsIds { get; set; } = new List<TKey>();
    }
}
