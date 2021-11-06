﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs
{
    public class MenuSubcategoryDTO : IDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public short MenuSubCategoryStateId { get; set; }

        public int MenuCategoryId { get; set; }
    }
}
