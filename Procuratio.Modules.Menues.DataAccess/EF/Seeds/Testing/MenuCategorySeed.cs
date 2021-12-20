using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Collections.Generic;
using System.Linq;

namespace Procuratio.Modules.Menu.DataAccess.EF.Seeds.Testing
{
    internal static class MenuCategorySeed
    {
        internal static void StartMenuCategorySeed(DbSet<MenuCategory> menuCategoryDbSet)
        {
            if (menuCategoryDbSet.Any()) return;

            menuCategoryDbSet.IgnoreQueryFilters();
            menuCategoryDbSet.AddRange(new MenuCategory()
            {
                Name = "Bebidas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 1,
                MenuSubCategories = new List<MenuSubcategory>()
                {
                    new MenuSubcategory()
                    {
                        Name = "Gaseosas",
                        Order = 1,
                        MenuSubCategoryStateId = (short)MenuSubCategoryState.State.Available,
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
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 2,
                MenuSubCategories = new List<MenuSubcategory>()
                {
                    new MenuSubcategory()
                    {
                        Name = "Tallarines",
                        Order = 1,
                        MenuSubCategoryStateId = (short)MenuSubCategoryState.State.Available,
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
