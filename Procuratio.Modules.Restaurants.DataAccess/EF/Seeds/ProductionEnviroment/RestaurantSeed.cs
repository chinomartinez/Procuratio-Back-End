using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Restaurant.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Procuratio.Modules.Restaurants.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class RestaurantSeed
    {
        internal static void StartRestaurantSeed(DbSet<Domain.Entities.Restaurant> restaurantDbSet)
        {
            if (restaurantDbSet.Any()) return;

            restaurantDbSet.AddRange(new Domain.Entities.Restaurant()
            {
                Id = 1,
                Name = "El DOMO",
                Slogan = "Experiencias sensoriales",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 1,
                        RestaurantId = 1,
                        Address = "Direccion falsa 5600",
                        Phone = "03034274171",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = 1,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = 2,
                                UnconstrainedValue = "true"
                            }
                        }
                    },
                    new Domain.Entities.Branch()
                    {
                        Id = 2,
                        RestaurantId = 1,
                        Address = "Direccion falsa 5600",
                        Phone = "03034274171",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = 1,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = 2,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            }, 
            new Domain.Entities.Restaurant()
            {
                Id = 2,
                Name = "La vieja esquina",
                Slogan = "Los mejores asados",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 3,
                        RestaurantId = 2,
                        Address = "Marcelo T. de Alvear 1715",
                        Phone = "03034274171",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = 1,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = 2,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            },
            new Domain.Entities.Restaurant()
            {
                Id = 3,
                Name = "Silveria",
                Slogan = "Los mejores lomitos",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 4,
                        RestaurantId = 2,
                        Address = "Direccion falsa 5600",
                        Phone = "03034274171",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = 1,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = 2,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            });
        }
    }
}
