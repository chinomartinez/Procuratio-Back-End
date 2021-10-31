using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.DataAccess.EF.Seeds.Testing
{
    internal static class ItemCategorySeed
    {
        internal static void StartItemCategorySeed(DbSet<ItemCategory> itemCategoryDbSet)
        {
            if (itemCategoryDbSet.Any()) return;

            itemCategoryDbSet.AddRange(new ItemCategory()
            {
                Name = "Bebidas",
                ItemCategoryStateId = (short)ItemCategoryState.State.Available,
                BranchId = 1,
                Order = 1,
                ItemSubCategories = new List<ItemSubCategory>()
                {
                    new ItemSubCategory()
                    {
                        Name = "Gaseosas",
                        Order = 1,
                        ItemSubCategoryStateId = (short)ItemSubCategoryState.State.Available,
                        BranchId = 1,
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = null,
                                ForKitchen = false,
                                Image = null,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = null,
                                ForKitchen = false,
                                Image = null,
                                Order = 2,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = null,
                                ForKitchen = false,
                                Image = null,
                                Order = 3,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            }
                        }
                    }
                }
            }, 
            new ItemCategory()
            {
                Name = "Pastas",
                ItemCategoryStateId = (short)ItemCategoryState.State.Available,
                BranchId = 1,
                Order = 2,
                ItemSubCategories = new List<ItemSubCategory>()
                {
                    new ItemSubCategory()
                    {
                        Name = "Tallarines",
                        Order = 1,
                        ItemSubCategoryStateId = (short)ItemSubCategoryState.State.Available,
                        BranchId = 1,
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = null,
                                ForKitchen = true,
                                Image = null,
                                Order = 1,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = null,
                                ForKitchen = true,
                                Image = null,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = null,
                                ForKitchen = true,
                                Image = null,
                                Order = 3,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            }
                        }
                    }
                }
            });
        }
    }
}
