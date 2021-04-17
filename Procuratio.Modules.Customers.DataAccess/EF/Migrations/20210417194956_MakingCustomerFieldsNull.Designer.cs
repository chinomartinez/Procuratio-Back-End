﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Procuratio.Modules.Customers.DataAccess;

namespace Procuratio.Modules.Customers.DataAccess.EF.Migrations
{
    [DbContext(typeof(CustomersDbContext))]
    [Migration("20210417194956_MakingCustomerFieldsNull")]
    partial class MakingCustomerFieldsNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Customers")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Procuratio.Modules.Customers.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Procuratio.Modules.Customers.Domain.Entities.Intermediate.CustomerXOrder", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerXOrderStateID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("CustomerID", "OrderID");

                    b.HasIndex("CustomerXOrderStateID");

                    b.ToTable("CustomerXOrder");
                });

            modelBuilder.Entity("Procuratio.Modules.Customers.Domain.Entities.State.CustomerXOrderState", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("CustomerXOrderState");
                });

            modelBuilder.Entity("Procuratio.Modules.Customers.Domain.Entities.Intermediate.CustomerXOrder", b =>
                {
                    b.HasOne("Procuratio.Modules.Customers.Domain.Entities.Customer", "MyProperty")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Customers.Domain.Entities.State.CustomerXOrderState", "CustomerXOrderState")
                        .WithMany("CustomersXOrders")
                        .HasForeignKey("CustomerXOrderStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerXOrderState");

                    b.Navigation("MyProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Customers.Domain.Entities.State.CustomerXOrderState", b =>
                {
                    b.Navigation("CustomersXOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
