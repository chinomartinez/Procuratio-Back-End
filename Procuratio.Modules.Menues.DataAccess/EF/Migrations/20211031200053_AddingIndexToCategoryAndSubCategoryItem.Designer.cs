﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Procuratio.Modules.Menues.DataAccess;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    [DbContext(typeof(MenuDbContext))]
    [Migration("20211031200053_AddingIndexToCategoryAndSubCategoryItem")]
    partial class AddingIndexToCategoryAndSubCategoryItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Menu")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("ForKitchen")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<short>("ItemStateId")
                        .HasColumnType("smallint");

                    b.Property<int>("ItemSubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<decimal?>("PriceInsideRestaurant")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<decimal?>("PriceOutsideRestaurant")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.HasKey("Id");

                    b.HasIndex("ItemStateId");

                    b.HasIndex("ItemSubCategoryId");

                    b.HasIndex("BranchId", "Order", "ItemSubCategoryId")
                        .IsUnique();

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.ItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<short>("ItemCategoryStateId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemCategoryStateId");

                    b.HasIndex("BranchId", "Order")
                        .IsUnique();

                    b.ToTable("ItemCategory");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.ItemSubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("ItemCategoryId")
                        .HasColumnType("int");

                    b.Property<short>("ItemSubCategoryStateId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemCategoryId");

                    b.HasIndex("ItemSubCategoryStateId");

                    b.HasIndex("BranchId", "Order", "ItemCategoryId")
                        .IsUnique();

                    b.ToTable("ItemSubCategory");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemCategoryState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ItemCategoryState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemSubCategoryState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ItemSubCategoryState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Item", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", "ItemState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("ItemStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.ItemSubCategory", "ItemSubCategory")
                        .WithMany("Items")
                        .HasForeignKey("ItemSubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemState");

                    b.Navigation("ItemSubCategory");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.ItemCategory", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.ItemCategoryState", "ItemCategoryState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("ItemCategoryStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCategoryState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.ItemSubCategory", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.ItemCategory", "ItemCategory")
                        .WithMany("ItemSubCategories")
                        .HasForeignKey("ItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.ItemSubCategoryState", "ItemSubCategoryState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("ItemSubCategoryStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCategory");

                    b.Navigation("ItemSubCategoryState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.ItemCategory", b =>
                {
                    b.Navigation("ItemSubCategories");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.ItemSubCategory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemCategoryState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemSubCategoryState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });
#pragma warning restore 612, 618
        }
    }
}