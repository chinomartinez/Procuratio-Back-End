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
            if (menuCategoryDbSet.IgnoreQueryFilters().Any()) return;

            menuCategoryDbSet.AddRange(new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 1,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
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
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
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
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 3,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
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
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
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
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 3,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 3,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 3,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 1
                            }
                }
            });
        }
    }
}
