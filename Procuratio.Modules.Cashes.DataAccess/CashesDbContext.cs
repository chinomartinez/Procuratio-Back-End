﻿using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.Domain.Entities;
using Procuratio.Modules.Cashes.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Cashes.DataAccess
{
    public class CashesDbContext : DbContext
    {
        #region DbSet of entities
        public DbSet<Cash> Cash { get; set; }
        public DbSet<MountType> MountType { get; set; }
        public DbSet<MovementType> MovementType { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        public DbSet<CashState> CashState { get; set; }
        #endregion

        public CashesDbContext(DbContextOptions<CashesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Cashes");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
