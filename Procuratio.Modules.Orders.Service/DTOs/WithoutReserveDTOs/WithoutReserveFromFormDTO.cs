using Microsoft.AspNetCore.Mvc;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class WithoutReserveFromFormDTO : IFromFormDTO
    {
        [Required]
        [ModelBinder(typeof(TypeBinder<List<int>>))]
        public List<int> TablesIds { get; set; } = new List<int>();
    }
}
