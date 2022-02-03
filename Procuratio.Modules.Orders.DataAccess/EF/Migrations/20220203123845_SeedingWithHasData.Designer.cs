﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Procuratio.Modules.Orders.DataAccess;

namespace Procuratio.Modules.Order.DataAccess.EF.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20220203123845_SeedingWithHasData")]
    partial class SeedingWithHasData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Order")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Procuratio.Modules.Order.Domain.Entities.intermediate.TableXOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "TableId");

                    b.HasIndex("TableId");

                    b.ToTable("TableXOrder");
                });

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

                    b.Property<short>("OrderStateId")
                        .HasColumnType("smallint");

                    b.Property<int>("WaiterId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("WaitingTimeForKitchen")
                        .HasColumnType("datetime2");

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

                    b.Property<string>("Comment")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

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

                    b.HasIndex("BranchId", "ItemId", "OrderId")
                        .IsUnique();

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

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            StateName = "Completado"
                        },
                        new
                        {
                            Id = (short)2,
                            StateName = "En curso"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            StateName = "Pendiente"
                        },
                        new
                        {
                            Id = (short)2,
                            StateName = "En proceso"
                        },
                        new
                        {
                            Id = (short)3,
                            StateName = "Para entrega"
                        },
                        new
                        {
                            Id = (short)4,
                            StateName = "Entregado"
                        },
                        new
                        {
                            Id = (short)5,
                            StateName = "Esperando el pago"
                        },
                        new
                        {
                            Id = (short)6,
                            StateName = "Pagado"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            StateName = "Pendiente"
                        },
                        new
                        {
                            Id = (short)2,
                            StateName = "Sin confirmar"
                        },
                        new
                        {
                            Id = (short)3,
                            StateName = "En curso"
                        },
                        new
                        {
                            Id = (short)4,
                            StateName = "Completada"
                        },
                        new
                        {
                            Id = (short)5,
                            StateName = "No vino"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            StateName = "Disponible"
                        },
                        new
                        {
                            Id = (short)2,
                            StateName = "Ocupada"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            StateName = "En curso"
                        },
                        new
                        {
                            Id = (short)2,
                            StateName = "Completado"
                        },
                        new
                        {
                            Id = (short)3,
                            StateName = "No vino"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = (short)2,
                            StateName = "En curso"
                        },
                        new
                        {
                            Id = (short)1,
                            StateName = "Completada"
                        });
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<short>("WithoutReserveStateId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("WithoutReserveStateId");

                    b.ToTable("WithoutReserve");
                });

            modelBuilder.Entity("Procuratio.Modules.Order.Domain.Entities.intermediate.TableXOrder", b =>
                {
                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Order", "Order")
                        .WithMany("TableXOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Orders.Domain.Entities.Table", "Table")
                        .WithMany("TableXOrder")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Table");
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

            modelBuilder.Entity("Procuratio.Modules.Orders.Domain.Entities.Order", b =>
                {
                    b.Navigation("Delivery");

                    b.Navigation("OrderDetails");

                    b.Navigation("Reserve");

                    b.Navigation("TableXOrders");

                    b.Navigation("TakeAway");

                    b.Navigation("WithoutReserve");
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
                    b.Navigation("TableXOrder");
                });
#pragma warning restore 612, 618
        }
    }
}
