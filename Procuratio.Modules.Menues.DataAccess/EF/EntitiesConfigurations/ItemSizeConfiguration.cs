﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    public class ItemSizeConfiguration : IEntityTypeConfiguration<ItemSize>
    {
        public void Configure(EntityTypeBuilder<ItemSize> builder)
        {
        }
    }
}
