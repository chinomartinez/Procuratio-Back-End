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
                BranchId = TGRID.BranchId,
                ItemSubCategories = new List<ItemSubCategory>()
                {
                    new ItemSubCategory()
                    {
                        Name = "Gaseosas",
                        Order = 1,
                        ItemSubCategoryStateId = (short)ItemSubCategoryState.State.Available,
                        BranchId = TGRID.BranchId,
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
                                BranchId = TGRID.BranchId
                            }
                        }
                    }
                }
            }, 
            new ItemCategory()
            {
                Name = "Pastas",
                ItemCategoryStateId = (short)ItemCategoryState.State.Available,
                BranchId = TGRID.BranchId,
                ItemSubCategories = new List<ItemSubCategory>()
                {
                    new ItemSubCategory()
                    {
                        Name = "Tallarines",
                        Order = 1,
                        ItemSubCategoryStateId = (short)ItemSubCategoryState.State.Available,
                        BranchId = TGRID.BranchId,
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = null,
                                ForKitchen = false,
                                Image = null,
                                Order = 1,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = TGRID.BranchId
                            }
                        }
                    }
                }
            });
        }
    }
}
