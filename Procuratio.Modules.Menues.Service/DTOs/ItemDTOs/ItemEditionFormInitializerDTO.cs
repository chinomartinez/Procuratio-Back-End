﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class ItemEditionFormInitializerDTO : IEntityEditionFormInitializerDTO<ItemDTO>
    {
        public ItemDTO BaseProperties { get; set; }
    }
}
