using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Order.Service.DTOs.TableDTOs
{
    public class TableCreationFormInitializerDTO : IEntityCreationFormInitializerDTO
    {
        public int NextTableNumber { get; set; }
    }
}
