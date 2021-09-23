using System.Collections.Generic;

namespace Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem
{
    /// <summary>
    /// DTO to fill a multiple selection option with the selected option
    /// </summary>
    /// <typeparam name="TKey">Type of key</typeparam>
    public class MultipleSelectListItemForEditionDTO
    {
        /// <summary>
        /// List of items for load the select list item
        /// </summary>
        public List<SelectListItemDTO> Items { get; set; } = new List<SelectListItemDTO>();

        /// <summary>
        /// Ids of the already selected options
        /// </summary>
        public List<string> SelectedOptionsIds { get; set; } = new List<string>();
    }
}
