using System.Collections.Generic;

namespace Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem
{
    /// <summary>
    /// DTO to fill a single selection option with the selected option
    /// </summary>
    /// <typeparam name="TKey">Type of key</typeparam>
    public class SingleSelectListItemForEditionDTO
    {
        /// <summary>
        /// List of items for load the select list item
        /// </summary>
        public List<SelectListItemDTO> Items { get; set; } = new List<SelectListItemDTO>();

        /// <summary>
        /// Id of the already selected option
        /// </summary>
        public string SelectedOptionId { get; set; }
    }
}
