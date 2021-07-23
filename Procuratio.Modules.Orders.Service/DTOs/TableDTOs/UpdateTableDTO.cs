using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Orders.Service.DTOs.TableDTOs
{
    public class UpdateTableDTO : IUpdateDTO
    {
        public int ID { get; set; }
        public int Capacity { get; set; }
        public short TableStateID { get; set; }
    }
}
