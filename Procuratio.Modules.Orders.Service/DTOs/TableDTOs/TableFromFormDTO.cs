using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Order.Service.DTOs.TableDTOs
{
    public class TableFromFormDTO : IFromFormDTO
    {
        [Required]
        public int Capacity { get; set; }    
    }
}
