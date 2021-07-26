using Microsoft.AspNetCore.Mvc;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Service.DTOs.DinerInDTOs
{
    public class UpdateDineInDTO : IUpdateDTO
    {
        public int ID { get; set; }

        [ModelBinder(binderType: typeof(TypeBinder<List<int>>))]
        public List<int> TablesIds { get; set; }
    }
}
