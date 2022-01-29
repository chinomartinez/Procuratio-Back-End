using Microsoft.AspNetCore.Mvc;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.DTOs.Branch
{
    public class SettingsFromFormDTO : IFromFormDTO
    {
        public List<SettingToUpdateDTO> SettingsToUpdate { get; set; }
    }
}
