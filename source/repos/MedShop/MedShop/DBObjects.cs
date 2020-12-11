using MedShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content) {

                if (!content.Category.Any())
                    content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Medicine.Any()) {
                content.AddRange(
                    new Medicine
                    {
                        name = "Ацецезон",
                        shortDesc = "При заболевании бронхов и легких",
                        longDesc = "Заболевания органов дыхания и состояния, сопровождающиеся образованием вязкой и слизисто-гнойной мокроты.Подготовка к бронхоскопии, бронхографии, аспирационному дренированию.Удаление вязкого секрета из дыхательных путей при посттравматических и послеоперационных состояниях.",
                        img = "~/img/azazenol.png",
                        isFavourite = true,
                        price = 2,
                        available = true,
                        Category = Categories["Медикаменты"]
                    },
                    new Medicine
                    {
                        name = "Бальзам Dr.Sante Keratin",
                        shortDesc = "Бальзам, 200мл, для тусклых и ломких волос",
                        longDesc = "Назначение: восстановление, смягчение, увлажнение, укрепление. Тип волос: ломкие, тонкие. Сделано в: Украина",
                        img = "~/img/Dr.Sante.jpg",
                        isFavourite = true,
                        price = 4,
                        available = true,
                        Category = Categories["Средства по уходу"]
                    },
                    new Medicine
                    {
                        name = "Пантенол",
                        shortDesc = "аэрозоль",
                        longDesc = "Применяется в комплексном лечении повреждений кожи.",
                        img = "https://images.app.goo.gl/UzbTyjzrgMckusjV7",
                        isFavourite = true,
                        price = 5,
                        available = true,
                        Category = Categories["Медикаменты"]
                    },
                    new Medicine
                    {
                        name = "Шампунь KALLOS Color",
                        shortDesc = "Шампунь для окрашенных и поврежденных волос, 1 л",
                        longDesc = "Назначение: для блеска, очищение, питание, тонизирование. Тип волос: окрашенные. Сделано в: Венгрия.",
                        img = "https://images.app.goo.gl/UzbTyjzrgMckusjV7",
                        isFavourite = true,
                        price = 3,
                        available = true,
                        Category = Categories["Средства по уходу"]
                    },
                    new Medicine
                    {
                        name = "Миг",
                        shortDesc = "Против головной боли",
                        longDesc = "Назначение: для блеска, очищение, питание, тонизирование. Тип волос: окрашенные. Сделано в: Венгрия.",
                        img = "https://images.app.goo.gl/UzbTyjzrgMckusjV7",
                        isFavourite = true,
                        price = 3,
                        available = false,
                        Category = Categories["Медикаменты"]
                    },
                    new Medicine
                    {
                        name = "Найз",
                        shortDesc = "Обезболивающее, 20 таблеток",
                        longDesc = "Назначение: для блеска, очищение, питание, тонизирование. Тип волос: окрашенные. Сделано в: Венгрия.",
                        img = "https://images.app.goo.gl/UzbTyjzrgMckusjV7",
                        isFavourite = true,
                        price = 3,
                        available = true,
                        Category = Categories["Медикаменты"]
                    },
                    new User
                    {
                        Email = "lubakach26@gmail.com",
                        Password = "lubakach",
                        Admin = "User"
                    },
                    new User
                    { 
                        Email="medicineshopby@gmail.com",
                        Password="medicineshopby",
                        Admin= "Admin"
                    }
             
                 );
            }
            content.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories {
            get {
                if (category == null) {
                    var list = new Category[] {
                        new Category { categoryName="Медикаменты", desc="Таблетки, порошки, сиропы, кремы, гели и тд"},
                        new Category { categoryName="Средства по уходу", desc="Декоративная косметика, кремы, шампуни, патчи тд"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }
    }
}
