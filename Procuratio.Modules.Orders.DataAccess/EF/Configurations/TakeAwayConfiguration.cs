﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Configurations
{
    public class TakeAwayConfiguration : IEntityTypeConfiguration<TakeAway>
    {
        public void Configure(EntityTypeBuilder<TakeAway> builder)
        {
        }
    }
}
