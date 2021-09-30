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
    internal static class CategoryItemSeed
    {
        internal static void StartCategoryItemSSeed(DbSet<CategoryItem> categoryItemDbSet)
        {
            if (categoryItemDbSet.Any()) return;

            categoryItemDbSet.AddRange(new CategoryItem()
            {
                Name = "Bebidas",
                CategoryItemStateId = (short)CategoryItemState.State.Available,
                BranchId = TGRID.BranchId,
                SubCategoryItems = new List<SubCategoryItem>()
                {
                    new SubCategoryItem()
                    {
                        Name = "Gaseosas",
                        Order = 1,
                        SubCategoryItemStateId = (short)SubCategoryItemState.State.Available,
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
            new CategoryItem()
            {
                Name = "Pastas",
                CategoryItemStateId = (short)CategoryItemState.State.Available,
                BranchId = TGRID.BranchId,
                SubCategoryItems = new List<SubCategoryItem>()
                {
                    new SubCategoryItem()
                    {
                        Name = "Tallarines",
                        Order = 1,
                        SubCategoryItemStateId = (short)SubCategoryItemState.State.Available,
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
