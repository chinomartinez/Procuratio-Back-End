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
    [Migration("20210930132352_ItemOrderIndex")]
    partial class ItemOrderIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Menu")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.CategoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<short>("CategoryItemStateId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryItemStateId");

                    b.ToTable("CategoryItem");
                });

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

                    b.Property<int>("SubCategoryItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemStateId");

                    b.HasIndex("SubCategoryItemId");

                    b.HasIndex("BranchId", "Order")
                        .IsUnique();

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.CategoryItemState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("CategoryItemState");
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

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.SubCategoryItemState", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("SubCategoryItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<short>("SubCategoryItemStateId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryItemStateId");

                    b.ToTable("SubCategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.CategoryItem", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.CategoryItemState", "CategoryItemState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("CategoryItemStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Item", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", "ItemState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("ItemStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", "SubCategoryItem")
                        .WithMany("Items")
                        .HasForeignKey("SubCategoryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemState");

                    b.Navigation("SubCategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.CategoryItem", "Category")
                        .WithMany("SubCategoryItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.SubCategoryItemState", "SubCategoryItemState")
                        .WithMany("CollectionNavigationProperty")
                        .HasForeignKey("SubCategoryItemStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SubCategoryItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.CategoryItem", b =>
                {
                    b.Navigation("SubCategoryItems");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.CategoryItemState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.SubCategoryItemState", b =>
                {
                    b.Navigation("CollectionNavigationProperty");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}