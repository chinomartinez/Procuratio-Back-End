﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations
{
    internal class DineInConfiguration : IEntityTypeConfiguration<DineIn>
    {
        public void Configure(EntityTypeBuilder<DineIn> builder)
        {
        }
    }
}