﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Procuratio.Modules.Menues.DataAccess;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    [DbContext(typeof(MenuDbContext))]
    [Migration("20210822233315_DeletingItemCategoryRelation")]
    partial class DeletingItemCategoryRelation
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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<short>("CategoryItemStateID")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryItemStateID");

                    b.ToTable("CategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("ForKitchen")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<short>("ItemStateID")
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

                    b.Property<int>("SubCategoryItemID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ItemStateID");

                    b.HasIndex("SubCategoryItemID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.CategoryItemState", b =>
                {
                    b.Property<short>("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("CategoryItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", b =>
                {
                    b.Property<short>("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("ItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.SubCategoryItemState", b =>
                {
                    b.Property<short>("ID")
                        .HasColumnType("smallint");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("SubCategoryItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<short>("SubCategoryItemStateID")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SubCategoryItemStateID");

                    b.ToTable("SubCategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.CategoryItem", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.CategoryItemState", "CategoryItemState")
                        .WithMany("CategoryItem")
                        .HasForeignKey("CategoryItemStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Item", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", "ItemState")
                        .WithMany("Items")
                        .HasForeignKey("ItemStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", "SubCategoryItem")
                        .WithMany("Items")
                        .HasForeignKey("SubCategoryItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemState");

                    b.Navigation("SubCategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.CategoryItem", "Category")
                        .WithMany("SubCategoryItems")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.SubCategoryItemState", "SubCategoryItemState")
                        .WithMany("SubCategoryItem")
                        .HasForeignKey("SubCategoryItemStateID")
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
                    b.Navigation("CategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.SubCategoryItemState", b =>
                {
                    b.Navigation("SubCategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}