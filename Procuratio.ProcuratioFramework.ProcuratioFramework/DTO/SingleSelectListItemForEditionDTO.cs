using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.ProcuratioFramework.DTO
{
    /// <summary>
    /// DTO to fill a single selection option with the selected option
    /// </summary>
    /// <typeparam name="TKey">Type of key</typeparam>
    public class SingleSelectListItemForEditionDTO<TKey>
    {
        /// <summary>
        /// List of items for load the select list item
        /// </summary>
        public List<SelectListItemDTO<TKey>> Items { get; set; } = new List<SelectListItemDTO<TKey>>();

        /// <summary>
        /// Id of the already selected option
        /// </summary>
        public TKey SelectedOptionId { get; set; }
    }
}
