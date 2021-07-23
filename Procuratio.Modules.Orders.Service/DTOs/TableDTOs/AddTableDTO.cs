using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Service.DTOs.TableDTOs
{
    public class AddTableDTO : IAddDTO
    {
        [Required]
        public int Capacity { get; set; }
    }
}
