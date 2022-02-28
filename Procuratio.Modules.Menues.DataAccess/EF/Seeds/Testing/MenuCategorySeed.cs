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

            menuCategoryDbSet.AddRange(
            new MenuCategory()
            {
                Name = "Entradas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 0,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Nachos reloaded",
                        Description = "Nachos con guacamole y queso cheddar",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 750,
                        PriceOutsideRestaurant = 750,
                        Code = "0001",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Craft cheese",
                        Description = "Bastón de muzzarella envueltos en masa de hojaldre con dips barbacoa",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 600,
                        PriceOutsideRestaurant = 600,
                        Code = "0002",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Tucuman roll",
                        Description = "Lo mejor de tucumán a cuchillo con dips brava",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 600,
                        PriceOutsideRestaurant = 600,
                        Code = "0003",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Queen pepiadas",
                        Description = "Arepas venezolanas rellanas con pollo, lactonesa, hojas de rucula y dips de guacamole",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 3,
                        PriceInsideRestaurant = 800,
                        PriceOutsideRestaurant = 800,
                        Code = "0004",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Chicken fingers",
                        Description = "Bocaditos de pollo rebozados con cereales y dip barbacoa",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 4,
                        PriceInsideRestaurant = 600,
                        PriceOutsideRestaurant = 600,
                        Code = "0005",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                },

            },
            new MenuCategory()
            {
                Name = "Papas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 1,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Manchada ala",
                        Description = "Papas con panceta y cheddar",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 600,
                        PriceOutsideRestaurant = 600,
                        Code = "0006",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Mexicanas",
                        Description = "Papas con guacamole",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 600,
                        PriceOutsideRestaurant = 600,
                        Code = "0007",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Bravas",
                        Description = "Papas con salsa picante",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 600,
                        PriceOutsideRestaurant = 600,
                        Code = "0008",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                }
            },
            new MenuCategory()
            {
                Name = "Tapeos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 2,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Tapeo arabe",
                        Description = "Humus de garbanzos, albóndigas de quepe con tuco, nuez y burgol, bobaganush con semillas de girasol tostadas, pan pita, dips de topenade, dips de tabulé, empanadas arabes",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 1500,
                        PriceOutsideRestaurant = 1500,
                        Code = "0009",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Tapeo mexicano",
                        Description = "Taco de carne y vegetales, cochinita pibil, nachos, quesadilla individual, dips de pico de gallo, guacamole, frijoles en pasta y hoy sauce",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 1500,
                        PriceOutsideRestaurant = 1500,
                        Code = "0010",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Tapeo ala manchada",
                        Description = "Craft cheese, tucuman rolls, chicken fingers, nachos, papas y dips de berenjena, morron, zanahoria y lactonesa",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 1500,
                        PriceOutsideRestaurant = 1500,
                        Code = "0011",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                }
            },
            new MenuCategory()
            {
                Name = "Sandwichs",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 3,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "La re-conquista",
                        Description = "Sandwitch de bondiola braseada con tomate y salsa BBQ casera",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 750,
                        PriceOutsideRestaurant = 750,
                        Code = "0012",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Poio sándwitch (es cordobés)",
                        Description = "Pollo, tomate, palta, papas, muzzarella y aderezo casero",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 650,
                        PriceOutsideRestaurant = 650,
                        Code = "0013",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Mr. veggie",
                        Description = "Vegetales asados, portobellos, rucula, muzzarella, disps de mayonesa de zanahora",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 750,
                        PriceOutsideRestaurant = 750,
                        Code = "0014",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Mr. lomo sandwich",
                        Description = "Lomo cortado a cuchillo, tomate, pimientos, portobellos, cebolla asada, mayonesa casera y papas rusticas",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 3,
                        PriceInsideRestaurant = 800,
                        PriceOutsideRestaurant = 800,
                        Code = "0015",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                }
            },
            new MenuCategory()
            {
                Name = "Burgers",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 4,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "French",
                        Description = "Roquefort, cebolla caramelizada y muzarella",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 780,
                        PriceOutsideRestaurant = 780,
                        Code = "0016",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Gringas",
                        Description = "Queso cheddar, lechuga y tomate",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 780,
                        PriceOutsideRestaurant = 780,
                        Code = "0017",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Tap room mini hamburguesas",
                        Description = "Degustación de mini hamburguesas (50 grs.)",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 850,
                        PriceOutsideRestaurant = 850,
                        Code = "0018",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Notorious B",
                        Description = "Cebolla, pimientos, muzarella, cheddar, lechuga, tomate, bacon y huevo",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 3,
                        PriceInsideRestaurant = 900,
                        PriceOutsideRestaurant = 900,
                        Code = "0018",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                }
            },
            new MenuCategory()
            {
                Name = "Flat bread",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 5,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Caprese",
                        Description = "Queso, muzarella, tomates cherry y albahaca",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 650,
                        PriceOutsideRestaurant = 650,
                        Code = "0019",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Espinaca a poni",
                        Description = "Queso muzarella, huevo de codorniz y espinaca",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 650,
                        PriceOutsideRestaurant = 650,
                        Code = "0020",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Funghi and bacon",
                        Description = "Portobellos, verdeo y panceta",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 650,
                        PriceOutsideRestaurant = 650,
                        Code = "0021",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Veggie bread",
                        Description = "Verduras asadas, queso muzarella, hojas de rucula",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 3,
                        PriceInsideRestaurant = 700,
                        PriceOutsideRestaurant = 700,
                        Code = "0022",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                }
            },
            new MenuCategory()
            {
                Name = "Ensaladas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 6,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "César clásica",
                        Description = "Ensalada caesar's (mix de verdes, crutones de pan de bagazo, panceta, aderezo caesar's y queso parmesano)",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 450,
                        PriceOutsideRestaurant = 450,
                        Code = "0023",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Ensalada manchada",
                        Description = "Mix de hojas verdes, vegetales asados, queso y dressing",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 500,
                        PriceOutsideRestaurant = 500,
                        Code = "0024",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                }
            },
            new MenuCategory()
            {
                Name = "Platos principales",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 7,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "El que sabe, sabe",
                        Description = "corte tomahawk, papas fritas, verduras asadas y salsa de champignones",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 1500,
                        PriceOutsideRestaurant = 1500,
                        Code = "0025",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Bondiola manchada",
                        Description = "Bondiola de cerdo agridulce con salsa mostaza, acompañada de puré de batata con chips de panceta",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 1200,
                        PriceOutsideRestaurant = 1200,
                        Code = "0026",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Pechuga fitnes",
                        Description = "Pechuga de pollo al limon, acompañada de ensalada de lechuga y tomate",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 800,
                        PriceOutsideRestaurant = 800,
                        Code = "0027",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Chicken quesadillas",
                        Description = "Quesadilla de pollo con cebollas, morrones salteados, nachos y dips de guacamole",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 3,
                        PriceInsideRestaurant = 900,
                        PriceOutsideRestaurant = 900,
                        Code = "0028",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Chicken revolution",
                        Description = "Pechuga d¿rellena con queso muzarella especiado, morrones asados y espinaca. Acompakado de vegetales asados y batatas doradas",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 4,
                        PriceInsideRestaurant = 1200,
                        PriceOutsideRestaurant = 1200,
                        Code = "0029",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                }
            },
            new MenuCategory()
            {
                Name = "Bebidas y postres",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 8,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Gaseosas",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 250,
                        PriceOutsideRestaurant = 250,
                        Code = "0030",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Aguas saborizadas",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 250,
                        PriceOutsideRestaurant = 250,
                        Code = "0031",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Limonada",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 250,
                        PriceOutsideRestaurant = 250,
                        Code = "0032",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Copa helada denut",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 3,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "0033",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Postre helado denut",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 4,
                        PriceInsideRestaurant = 400,
                        PriceOutsideRestaurant = 400,
                        Code = "0034",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Torta susana marzola",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 5,
                        PriceInsideRestaurant = 400,
                        PriceOutsideRestaurant = 400,
                        Code = "0035",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                }
            },
            new MenuCategory()
            {
                Name = "Birras",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 9,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Blonde pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "00036",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Blonde 1/2 pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 200,
                        Code = "00037",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Irish red pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "0038",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Irish red 1/2 pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 3,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 200,
                        Code = "0039",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Fruit bier pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 4,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "0040",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Fruit bier 1/2 pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 5,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 200,
                        Code = "0041",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Hefeweizen pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 6,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "0042",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Hefeweizen 1/2 pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 7,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 200,
                        Code = "0043",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Oatmeal stout pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 8,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "0044",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Oatmeal stout 1/2 pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 9,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 200,
                        Code = "0045",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Smoked pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 10,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "0046",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Smoked 1/2 pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 11,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 200,
                        Code = "0047",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Apa pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 12,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "0048",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Apa 1/2 pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 13,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 200,
                        Code = "0049",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Session ipa pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 14,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "0050",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Session ipa 1/2 pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 15,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 200,
                        Code = "0051",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "American pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 16,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 300,
                        Code = "0052",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "American 1/2 pinta",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 17,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 200,
                        Code = "0053",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                }
            },
            new MenuCategory()
            {
                Name = "Tragos clasicos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 10,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Fernet con cola",
                        Description = "Fernet dos onzas, gaseosa cola y hielo",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 490,
                        PriceOutsideRestaurant = 490,
                        Code = "0054",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Mojito",
                        Description = "Ron carta blanca dos onzas, jugo de limnon, menta, agua co ngas, almíbar y hielo",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 490,
                        PriceOutsideRestaurant = 490,
                        Code = "0055",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                }
            },
            new MenuCategory()
            {
                Name = "Cocktails",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 1,
                Order = 11,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Beer julep",
                        Description = "Cynar dos onzas, Jugo de pomelo dos onzas, Cerveza de trigo Hefeweizen dos onzas, Menta - Gaseosa de tónica o jengibre y Hielo",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 490,
                        PriceOutsideRestaurant = 490,
                        Code = "0056",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    },
                    new Item()
                    {
                        Name = "Negroni tradicional",
                        Description = "Gin dos onzas, Campari dos onzas, Vermut Rosso dos onzas y Hielo dos rocas",
                        ForKitchen = true,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 550,
                        PriceOutsideRestaurant = 550,
                        Code = "0057",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 1
                    }
                }
            },

            // vvv Categorias iguales para el resto de sucursales vvv

            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 2,
                Order = 0,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Coca cola 500 ml",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 0,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 150,
                        Code = "0001",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 2
                    },
                    new Item()
                    {
                        Name = "Sprite 500 ml",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 1,
                        PriceInsideRestaurant = 200,
                        PriceOutsideRestaurant = 150,
                        Code = "0003",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 2
                    },
                    new Item()
                    {
                        Name = "Fanta 1 L",
                        Description = string.Empty,
                        ForKitchen = false,
                        Image = string.Empty,
                        Order = 2,
                        PriceInsideRestaurant = 300,
                        PriceOutsideRestaurant = 250,
                        Code = "0004",
                        ItemStateId = (short)ItemState.State.Available,
                        BranchId = 2
                    }
                }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 2,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 2
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 2
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 2
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 2,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 2
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 2
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 2
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 3,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 3
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 3
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 3
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 3,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 3
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 3
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 3
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 3,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 3
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 3
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 3
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 4,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 4
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 4
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 4
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 4,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 4
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 4
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 4
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 4,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 4
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 4
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 4
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 5,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 5
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 5
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 5
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 5,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 5
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 5
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 5
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 5,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 5
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 5
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 5
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 6,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 6
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 6
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 6
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 6,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 6
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 6
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 6
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 6,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 6
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 6
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 6
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 7,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 7
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 7
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 7
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 7,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 7
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 7
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 7
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 7,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 7
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 7
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 7
                            }
                }
            }, new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 8,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 8
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 8
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 8
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 8,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 8
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 8
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 8
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 8,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 8
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 8
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 8
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 9,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 9
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 9
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 9
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 9,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 9
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 9
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 9
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 9,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 9
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 9
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 9
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 10,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 10
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 10
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 10
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 10,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 10
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 10
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 10
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 10,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 10
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 10
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 10
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 11,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 11
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 11
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 11
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 11,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 11
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 11
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 11
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 11,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 11
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 11
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 11
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Gaseosas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 12,
                Order = 0,
                Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0001",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 12
                            },
                            new Item()
                            {
                                Name = "Sprite 500 ml",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 200,
                                PriceOutsideRestaurant = 150,
                                Code = "0003",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 12
                            },
                            new Item()
                            {
                                Name = "Fanta 1 L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 300,
                                PriceOutsideRestaurant = 250,
                                Code = "0004",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 12
                            }
                        }
            },
            new MenuCategory()
            {
                Name = "Pastas",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 12,
                Order = 1,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Espagueti",
                                Description = "Con salsa bolognesa",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 350,
                                PriceOutsideRestaurant = 275,
                                Code = "0002",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 12
                            },
                            new Item()
                            {
                                Name = "Ñoquis",
                                Description = "Con queso provolone",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0005",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 12
                            },
                            new Item()
                            {
                                Name = "Rigatoni",
                                Description = "Con salsa a elección",
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 150,
                                PriceOutsideRestaurant = 125,
                                Code = "0006",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 12
                            }
                }
            },
            new MenuCategory()
            {
                Name = "Vinos",
                MenuCategoryStateId = (short)MenuCategoryState.State.Available,
                BranchId = 12,
                Order = 2,
                Items = new List<Item>()
                {
                            new Item()
                            {
                                Name = "Toro 1L",
                                Description = string.Empty,
                                ForKitchen = true,
                                Image = string.Empty,
                                Order = 0,
                                PriceInsideRestaurant = 400,
                                PriceOutsideRestaurant = 500,
                                Code = "0007",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 12
                            },
                            new Item()
                            {
                                Name = "Cristobal 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 1,
                                PriceInsideRestaurant = 425,
                                PriceOutsideRestaurant = 525,
                                Code = "0008",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 12
                            },
                            new Item()
                            {
                                Name = "Santa Isabel 1L",
                                Description = string.Empty,
                                ForKitchen = false,
                                Image = string.Empty,
                                Order = 2,
                                PriceInsideRestaurant = 325,
                                PriceOutsideRestaurant = 225,
                                Code = "0009",
                                ItemStateId = (short)ItemState.State.Available,
                                BranchId = 12
                            }
                }
            });
        }
    }
}
