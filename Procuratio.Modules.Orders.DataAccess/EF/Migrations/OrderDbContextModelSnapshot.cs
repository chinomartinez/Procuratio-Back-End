﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Procuratio.Modules.Orders.DataAccess;

namespace Procuratio.Modules.Order.DataAccess.EF.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Order")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<short>("DeliveryStateId")
                        .HasColumnType("smallint");

                    b.Property<string>("DestinyDirection")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryStateId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("KitchenNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("OrderStateId")
                        .HasColumnType("smallint");

                    b.Property<int>("WaiterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderStateId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityInKitchen")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Reserve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<short>("NumberOfDiners")
                        .HasColumnType("smallint");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<short>("ReserveStateId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.HasIndex("ReserveStateId");

                    b.ToTable("Reserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.DeliveryState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.OrderState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("OrderState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.ReserveState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ReserveState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.TableState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TableState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.TakeAwayState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TakeAwayState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.WithoutReserveState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("WithoutReserveState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.Property<short>("TableStateId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("TableStateId");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.TakeAway", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<short>("TakeAwayStateId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("TakeAwayStateId");

                    b.ToTable("TakeAway");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.WithoutReserve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<short>("WithoutReserveStateId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("WithoutReserveStateId");

                    b.ToTable("WithoutReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.intermediate.TableXReserve", b =>
                {
                    b.Property<int>("ReserveId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.HasKey("ReserveId", "TableId");

                    b.HasIndex("TableId");

                    b.ToTable("TableXReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.intermediate.TableXWithoutReserve", b =>
                {
                    b.Property<int>("WithoutReserveId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.HasKey("WithoutReserveId", "TableId");

                    b.HasIndex("TableId");

                    b.ToTable("TableXWithoutReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Delivery", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.DeliveryState", "DeliveryState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("DeliveryStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithOne("Delivery")
                        .HasForeignKey("Procuratio.Modules.Orders.Domain.Entities.Delivery", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryState");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Order", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.OrderState", "OrderState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("OrderStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Reserve", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithOne("Reserve")
                        .HasForeignKey("Procuratio.Modules.Orders.Domain.Entities.Reserve", "OrderId");

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.ReserveState", "ReserveState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("ReserveStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ReserveState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Table", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.TableState", "TableState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("TableStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TableState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.TakeAway", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithOne("TakeAway")
                        .HasForeignKey("Procuratio.Modules.Orders.Domain.Entities.TakeAway", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.TakeAwayState", "TakeAwayState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("TakeAwayStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("TakeAwayState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.WithoutReserve", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithOne("WithoutReserve")
                        .HasForeignKey("Procuratio.Modules.Orders.Domain.Entities.WithoutReserve", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.WithoutReserveState", "WithoutReserveState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("WithoutReserveStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("WithoutReserveState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.intermediate.TableXReserve", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Reserve", "Reserve")
                        .WithMany("TableXReserve")
                        .HasForeignKey("ReserveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Table", "Table")
                        .WithMany("TableXReserve")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserve");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.intermediate.TableXWithoutReserve", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Table", "Table")
                        .WithMany("TableXWithoutReserve")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.WithoutReserve", "WithoutReserve")
                        .WithMany("TableXWithoutReserve")
                        .HasForeignKey("WithoutReserveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");

                    b.Navigation("WithoutReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Order", b =>
                {
                    b.Navigation("Delivery");

                    b.Navigation("OrderDetails");

                    b.Navigation("Reserve");

                    b.Navigation("TakeAway");

                    b.Navigation("WithoutReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Reserve", b =>
                {
                    b.Navigation("TableXReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.DeliveryState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.OrderState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.ReserveState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.TableState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.TakeAwayState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.WithoutReserveState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Table", b =>
                {
                    b.Navigation("TableXReserve");

                    b.Navigation("TableXWithoutReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.WithoutReserve", b =>
                {
                    b.Navigation("TableXWithoutReserve");
                });
#pragma warning restore 612, 618
        }
    }
}
