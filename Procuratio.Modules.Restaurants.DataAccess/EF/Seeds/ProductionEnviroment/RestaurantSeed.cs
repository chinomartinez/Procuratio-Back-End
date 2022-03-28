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
                Name = "Ala manchada",
                Slogan = "Conquistando Cervezas",
                Image = "https://procuratio.blob.core.windows.net/restaurant/274092024_716814666392034_400891890390236402_n.jpg",
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 1,
                        RestaurantId = 1,
                        Address = "Rivadavia 430 - Villa María",
                        Phone = "0353 420-3933",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 1,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    },
                    new Domain.Entities.Branch()
                    {
                        Id = 2,
                        RestaurantId = 1,
                        Address = "Gral. Paz 769 - Villa nueva",
                        Phone = "0353 475-3453",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 2,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 2,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 2,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
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
                Slogan = "Especialistas en parrilladas",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 3,
                        RestaurantId = 2,
                        Address = "Marcelo T. de Alvear 1715",
                        Phone = "0353 452-9248",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 3,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 3,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 3,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
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
                        RestaurantId = 3,
                        Address = "Bv. Argentino 1670 - Villa María",
                        Phone = "0353 428-2938",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 4,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 4,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 4,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            },
            new Domain.Entities.Restaurant()
            {
                Id = 4,
                Name = "El DOMO",
                Slogan = "Experiencias sensoriales",
                Image = "https://procuratio.blob.core.windows.net/restaurant/119075636_343625426999221_2829561509024207942_n.jpg",
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 5,
                        RestaurantId = 2,
                        Address = "Sta. Fe 222-298 - Villa María",
                        Phone = "03034274171",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 5,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 5,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 5,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            },
            new Domain.Entities.Restaurant()
            {
                Id = 5,
                Name = "Soho",
                Slogan = "Eslogan soho",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 6,
                        RestaurantId = 5,
                        Address = "Av. Dante Alighieri, Av. Costanera 11 - Villa María",
                        Phone = "0353 452-7528",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 6,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 6,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 6,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            },
            new Domain.Entities.Restaurant()
            {
                Id = 6,
                Name = "Vincent",
                Slogan = "Eslogan Vincent",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 7,
                        RestaurantId = 6,
                        Address = "Av. Dante Alighieri, Av. Costanera 11 - Villa María",
                        Phone = "353 452-7598",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 7,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 7,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 7,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            },
            new Domain.Entities.Restaurant()
            {
                Id = 7,
                Name = "Centro Vasco",
                Slogan = "Eslogan Centro Vasco",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 8,
                        RestaurantId = 7,
                        Address = "Lisandro de la Torre 33 - Villa María",
                        Phone = "0353 453-4400",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 8,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 8,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 8,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            },
            new Domain.Entities.Restaurant()
            {
                Id = 8,
                Name = "Quartino Ristorante",
                Slogan = "Eslogan Quartino Ristorante",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 9,
                        RestaurantId = 8,
                        Address = "Av. Hipólito Yrigoyen 329 - Villa María",
                        Phone = "0353 454-8487",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 9,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 9,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 9,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            },
            new Domain.Entities.Restaurant()
            {
                Id = 9,
                Name = "Rigoletto",
                Slogan = "Eslogan Rigoletto",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 10,
                        RestaurantId = 9,
                        Address = "Mendoza 1002 - Villa María",
                        Phone = "0353 461-4266",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 10,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 10,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 10,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            },
            new Domain.Entities.Restaurant()
            {
                Id = 10,
                Name = "Mood",
                Slogan = "Eslogan Mood",
                Image = "https://procuratio.blob.core.windows.net/restaurant/263414002_242413577981050_2607462784476320153_n.jpg",
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 11,
                        RestaurantId = 10,
                        Address = "Entre Ríos 770 - Villa María",
                        Phone = "0353 481-0430",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 11,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 11,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 11,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            },
            new Domain.Entities.Restaurant()
            {
                Id = 11,
                Name = "Ribera Pampa",
                Slogan = "Eslogan Ribera Pampa",
                Image = string.Empty,
                Branches = new List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 12,
                        RestaurantId = 11,
                        Address = "Av. Libertador Gral. San Martín 129 - Villa María",
                        Phone = "03534274171",
                        Instagram = "https://www.instagram.com/procuratiosoftware/",
                        Location = string.Empty,
                        DateWithdrawn = null,
                        BranchSettings = new List<BranchSetting>()
                        {
                            new BranchSetting()
                            {
                                BranchId = 12,
                                SettingId = (int)Setting.Type.OnlineMenu,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 12,
                                SettingId = (int)Setting.Type.OrderFromTable,
                                UnconstrainedValue = "true"
                            },
                            new BranchSetting()
                            {
                                BranchId = 12,
                                SettingId = (int)Setting.Type.ShowRestaurantInOnlineMenu,
                                UnconstrainedValue = "true"
                            }
                        }
                    }
                }
            });
        }
    }
}
