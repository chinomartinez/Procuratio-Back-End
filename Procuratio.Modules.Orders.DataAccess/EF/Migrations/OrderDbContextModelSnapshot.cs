﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Procuratio.Modules.Orders.DataAccess;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<short>("DeliveryStateID")
                        .HasColumnType("smallint");

                    b.Property<string>("DestinyDirection")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DeliveryStateID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.DineIn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<short>("DinerInStateID")
                        .HasColumnType("smallint");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DinerInStateID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.ToTable("DineIn");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("KitchenNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("OrderStateID")
                        .HasColumnType("smallint");

                    b.Property<int>("WaiterID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderStateID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityInKitchen")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Reserve", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<short>("NumberOfDiners")
                        .HasColumnType("smallint");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<short>("ReserveStateID")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("OrderID")
                        .IsUnique()
                        .HasFilter("[OrderID] IS NOT NULL");

                    b.HasIndex("ReserveStateID");

                    b.ToTable("Reserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.DeliveryState", b =>
                {
                    b.Property<short>("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("DeliveryState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.DineInState", b =>
                {
                    b.Property<short>("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("DineInState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.OrderState", b =>
                {
                    b.Property<short>("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("OrderState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.ReserveState", b =>
                {
                    b.Property<short>("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("ReserveState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.TableState", b =>
                {
                    b.Property<short>("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("TableState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.TakeAwayState", b =>
                {
                    b.Property<short>("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("TakeAwayState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Table", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.Property<short>("TableStateID")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("TableStateID");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.TakeAway", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<short>("TakeAwayStateID")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.HasIndex("TakeAwayStateID");

                    b.ToTable("TakeAway");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.intermediate.TableXDinerIn", b =>
                {
                    b.Property<int>("DinnerInID")
                        .HasColumnType("int");

                    b.Property<int>("TableID")
                        .HasColumnType("int");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.HasKey("DinnerInID", "TableID");

                    b.HasIndex("TableID");

                    b.ToTable("TableXDineIn");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.intermediate.TableXReserve", b =>
                {
                    b.Property<int>("ReserveID")
                        .HasColumnType("int");

                    b.Property<int>("TableID")
                        .HasColumnType("int");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.HasKey("ReserveID", "TableID");

                    b.HasIndex("TableID");

                    b.ToTable("TableXReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Delivery", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.DeliveryState", "DeliveryState")
                        .WithMany("Deliveries")
                        .HasForeignKey("DeliveryStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithOne("Delivery")
                        .HasForeignKey("Procuratio.Modules.Orders.Domain.Entities.Delivery", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryState");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.DineIn", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.DineInState", "DinerInState")
                        .WithMany("DinerIn")
                        .HasForeignKey("DinerInStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithOne("DinerIn")
                        .HasForeignKey("Procuratio.Modules.Orders.Domain.Entities.DineIn", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DinerInState");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Order", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.OrderState", "OrderState")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Reserve", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithOne("Reserve")
                        .HasForeignKey("Procuratio.Modules.Orders.Domain.Entities.Reserve", "OrderID");

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.ReserveState", "ReserveState")
                        .WithMany("Reserve")
                        .HasForeignKey("ReserveStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ReserveState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Table", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.TableState", "TableState")
                        .WithMany("Table")
                        .HasForeignKey("TableStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TableState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.TakeAway", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithOne("TakeAway")
                        .HasForeignKey("Procuratio.Modules.Orders.Domain.Entities.TakeAway", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.State.TakeAwayState", "TakeAwayState")
                        .WithMany("TakeAways")
                        .HasForeignKey("TakeAwayStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("TakeAwayState");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.intermediate.TableXDinerIn", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.DineIn", "DinnerIn")
                        .WithMany("TableXDinerIn")
                        .HasForeignKey("DinnerInID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Table", "Table")
                        .WithMany("TableXDinerIn")
                        .HasForeignKey("TableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DinnerIn");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.intermediate.TableXReserve", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Reserve", "Reserve")
                        .WithMany("TableXReserve")
                        .HasForeignKey("ReserveID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Table", "Table")
                        .WithMany("TableXReserve")
                        .HasForeignKey("TableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserve");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.DineIn", b =>
                {
                    b.Navigation("TableXDinerIn");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Order", b =>
                {
                    b.Navigation("Delivery");

                    b.Navigation("DinerIn");

                    b.Navigation("OrderDetails");

                    b.Navigation("Reserve");

                    b.Navigation("TakeAway");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Reserve", b =>
                {
                    b.Navigation("TableXReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.DeliveryState", b =>
                {
                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.DineInState", b =>
                {
                    b.Navigation("DinerIn");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.OrderState", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.ReserveState", b =>
                {
                    b.Navigation("Reserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.TableState", b =>
                {
                    b.Navigation("Table");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.State.TakeAwayState", b =>
                {
                    b.Navigation("TakeAways");
                });

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Table", b =>
                {
                    b.Navigation("TableXDinerIn");

                    b.Navigation("TableXReserve");
                });
#pragma warning restore 612, 618
        }
    }
}
