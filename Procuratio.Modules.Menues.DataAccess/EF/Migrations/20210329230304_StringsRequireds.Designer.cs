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
    [DbContext(typeof(MenuesDbContext))]
    [Migration("20210329230304_StringsRequireds")]
    partial class StringsRequireds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Menues")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.CategoryItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryItemStateID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryItemStateID");

                    b.ToTable("CategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.ExtraIngredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("DeliveryPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("DinerInPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ExtraIngredientStateID")
                        .HasColumnType("int");

                    b.Property<decimal?>("MenuPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TakeAwayPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ID");

                    b.HasIndex("ExtraIngredientStateID");

                    b.ToTable("ExtraIngredient");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Intermediate.ExtraIngredientXItem", b =>
                {
                    b.Property<int>("ExtraIngredientID")
                        .HasColumnType("int");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("ExtraIngredientXItemStateID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ExtraIngredientID", "ItemID");

                    b.HasIndex("ExtraIngredientXItemStateID");

                    b.HasIndex("ItemID");

                    b.ToTable("ExtraIngredientXItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Intermediate.ItemXPromotion", b =>
                {
                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("PromotionID")
                        .HasColumnType("int");

                    b.Property<int>("ItemXPromotionOrder")
                        .HasColumnType("int");

                    b.Property<int?>("ItemXPromotionStateID")
                        .HasColumnType("int");

                    b.Property<int?>("PromotionDayOfWeekTimeRangeID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ItemID", "PromotionID");

                    b.HasIndex("ItemXPromotionStateID");

                    b.HasIndex("PromotionDayOfWeekTimeRangeID");

                    b.HasIndex("PromotionID");

                    b.ToTable("ItemXPromotion");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryItemID")
                        .HasColumnType("int");

                    b.Property<decimal?>("DeliveryPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal?>("DinerInPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool>("ForKitchen")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ItemOrder")
                        .HasColumnType("int");

                    b.Property<int>("ItemStateID")
                        .HasColumnType("int");

                    b.Property<decimal?>("MenuPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<int?>("SubCategoryItemID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TakeAwayPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryItemID");

                    b.HasIndex("ItemStateID");

                    b.HasIndex("SubCategoryItemID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Promotion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("DeliveryPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("DinerInPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("MenuPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int?>("PromotionDayOfWeekID")
                        .HasColumnType("int");

                    b.Property<int>("PromotionOrder")
                        .HasColumnType("int");

                    b.Property<int>("PromotionStateID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TakeAwayPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ID");

                    b.HasIndex("PromotionDayOfWeekID");

                    b.HasIndex("PromotionStateID");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.PromotionDayOfWeek", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PromotionDayOfWeekTimeRangeID")
                        .HasColumnType("int");

                    b.Property<int>("PromotionID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PromotionDayOfWeekTimeRangeID");

                    b.ToTable("PromotionDayOfWeek");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.PromotionDayOfWeekTimeRange", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Begin")
                        .HasColumnType("time");

                    b.Property<int>("DayOFweek")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Finish")
                        .HasColumnType("time");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PromotionDayOfWeekTimeRange");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.CategoryItemState", b =>
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

                    b.ToTable("CategoryItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ExtraIngredientState", b =>
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

                    b.ToTable("ExtraIngredientState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ExtraIngredientXItemState", b =>
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

                    b.ToTable("ExtraIngredientXItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", b =>
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

                    b.ToTable("ItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemXPromotionState", b =>
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

                    b.ToTable("ItemXPromotionState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.PromotionState", b =>
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

                    b.ToTable("PromotionState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.SubCategoryItemState", b =>
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

                    b.ToTable("SubCategoryItemState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryItemOrder")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryItemStateID")
                        .HasColumnType("int");

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

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.ExtraIngredient", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.ExtraIngredientState", "ExtraIngredientState")
                        .WithMany("ExtraIngredient")
                        .HasForeignKey("ExtraIngredientStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraIngredientState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Intermediate.ExtraIngredientXItem", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.ExtraIngredient", "ExtraIngredient")
                        .WithMany("ExtraIngredientXItem")
                        .HasForeignKey("ExtraIngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.ExtraIngredientXItemState", "ExtraIngredientXItemState")
                        .WithMany("ExtraIngredientXItem")
                        .HasForeignKey("ExtraIngredientXItemStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.Item", "Item")
                        .WithMany("ExtrasIngredientsXItem")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraIngredient");

                    b.Navigation("ExtraIngredientXItemState");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Intermediate.ItemXPromotion", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.Item", "Item")
                        .WithMany("ItemsXPromotions")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.ItemXPromotionState", "ItemXPromotionState")
                        .WithMany("ItemsXPromotion")
                        .HasForeignKey("ItemXPromotionStateID");

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.PromotionDayOfWeekTimeRange", null)
                        .WithMany("ItemXPromotion")
                        .HasForeignKey("PromotionDayOfWeekTimeRangeID");

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.Promotion", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ItemXPromotionState");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Item", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.CategoryItem", "CategoryItem")
                        .WithMany("Items")
                        .HasForeignKey("CategoryItemID");

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", "ItemState")
                        .WithMany("Items")
                        .HasForeignKey("ItemStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.SubCategoryItem", "SubCategoryItem")
                        .WithMany("Items")
                        .HasForeignKey("SubCategoryItemID");

                    b.Navigation("CategoryItem");

                    b.Navigation("ItemState");

                    b.Navigation("SubCategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Promotion", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.PromotionDayOfWeek", null)
                        .WithMany("Promotion")
                        .HasForeignKey("PromotionDayOfWeekID");

                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.State.PromotionState", "PromotionState")
                        .WithMany("Promotions")
                        .HasForeignKey("PromotionStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PromotionState");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.PromotionDayOfWeek", b =>
                {
                    b.HasOne("Procuratio.Modules.Menues.Domain.Entities.PromotionDayOfWeekTimeRange", "PromotionDayOfWeekTimeRange")
                        .WithMany("PromotionsDayOfWeek")
                        .HasForeignKey("PromotionDayOfWeekTimeRangeID");

                    b.Navigation("PromotionDayOfWeekTimeRange");
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
                    b.Navigation("Items");

                    b.Navigation("SubCategoryItems");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.ExtraIngredient", b =>
                {
                    b.Navigation("ExtraIngredientXItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.Item", b =>
                {
                    b.Navigation("ExtrasIngredientsXItem");

                    b.Navigation("ItemsXPromotions");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.PromotionDayOfWeek", b =>
                {
                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.PromotionDayOfWeekTimeRange", b =>
                {
                    b.Navigation("ItemXPromotion");

                    b.Navigation("PromotionsDayOfWeek");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.CategoryItemState", b =>
                {
                    b.Navigation("CategoryItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ExtraIngredientState", b =>
                {
                    b.Navigation("ExtraIngredient");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ExtraIngredientXItemState", b =>
                {
                    b.Navigation("ExtraIngredientXItem");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemState", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.ItemXPromotionState", b =>
                {
                    b.Navigation("ItemsXPromotion");
                });

            modelBuilder.Entity("Procuratio.Modules.Menues.Domain.Entities.State.PromotionState", b =>
                {
                    b.Navigation("Promotions");
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
