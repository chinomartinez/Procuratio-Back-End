﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Procuratio.Modules.Cashes.DataAccess;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Migrations
{
    [DbContext(typeof(CashesDbContext))]
    partial class CashesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Cashes")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Procuratio.Modules.Cashes.Domain.Entities.Cash", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CashStateID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Mount")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("MountTypeID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CashStateID");

                    b.HasIndex("MountTypeID");

                    b.ToTable("Cash");
                });

            modelBuilder.Entity("Procuratio.Modules.Cashes.Domain.Entities.MountType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MovementTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MovementTypeID");

                    b.ToTable("MountType");
                });

            modelBuilder.Entity("Procuratio.Modules.Cashes.Domain.Entities.MovementType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovementTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("MovementsTypeID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MovementsTypeID");

                    b.ToTable("MovementType");
                });

            modelBuilder.Entity("Procuratio.Modules.Cashes.Domain.Entities.State.CashState", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("CashState");
                });

            modelBuilder.Entity("Procuratio.Modules.Cashes.Domain.Entities.Cash", b =>
                {
                    b.HasOne("Procuratio.Modules.Cashes.Domain.Entities.State.CashState", "CashState")
                        .WithMany("Cashes")
                        .HasForeignKey("CashStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Cashes.Domain.Entities.MountType", "MountType")
                        .WithMany("Cashes")
                        .HasForeignKey("MountTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CashState");

                    b.Navigation("MountType");
                });

            modelBuilder.Entity("Procuratio.Modules.Cashes.Domain.Entities.MountType", b =>
                {
                    b.HasOne("Procuratio.Modules.Cashes.Domain.Entities.MovementType", "MovementType")
                        .WithMany()
                        .HasForeignKey("MovementTypeID");

                    b.Navigation("MovementType");
                });

            modelBuilder.Entity("Procuratio.Modules.Cashes.Domain.Entities.MovementType", b =>
                {
                    b.HasOne("Procuratio.Modules.Cashes.Domain.Entities.MovementType", "MovementsType")
                        .WithMany()
                        .HasForeignKey("MovementsTypeID");

                    b.Navigation("MovementsType");
                });

            modelBuilder.Entity("Procuratio.Modules.Cashes.Domain.Entities.MountType", b =>
                {
                    b.Navigation("Cashes");
                });

            modelBuilder.Entity("Procuratio.Modules.Cashes.Domain.Entities.State.CashState", b =>
                {
                    b.Navigation("Cashes");
                });
#pragma warning restore 612, 618
        }
    }
}
