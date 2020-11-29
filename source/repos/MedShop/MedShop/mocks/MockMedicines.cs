using MedShop.Interfaces;
using MedShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.mocks
{
    public class MockMedicines : IAllMedicines
    {

        private readonly IMedicinesCategory _categoryMedicines = new MockCategory();
        public IEnumerable<Medicine> Medicines {
            get {
                return new List<Medicine> {
                    new Medicine{
                        name ="Ацецезон",
                        shortDesc ="При заболевании бронхов и легких",
                        longDesc ="Заболевания органов дыхания и состояния, сопровождающиеся образованием вязкой и слизисто-гнойной мокроты.Подготовка к бронхоскопии, бронхографии, аспирационному дренированию.Удаление вязкого секрета из дыхательных путей при посттравматических и послеоперационных состояниях.",
                        img ="~/img/azazenol.png",
                        isFavourite =true,
                        price=2,
                        available =true,
                        Category =_categoryMedicines.AllCategories.First()},
                    new Medicine{
                        name ="Бальзам Dr.Sante Keratin",
                        shortDesc ="Бальзам, 200мл, для тусклых и ломких волос",
                        longDesc ="Назначение: восстановление, смягчение, увлажнение, укрепление. Тип волос: ломкие, тонкие. Сделано в: Украина",
                        img ="~/img/Dr.Sante.jpg",
                        isFavourite =true,
                        available =true,
                        Category =_categoryMedicines.AllCategories.Last()},
                    new Medicine{
                        name ="Пантенол",
                        shortDesc ="аэрозоль",
                        longDesc ="Применяется в комплексном лечении повреждений кожи.",
                        img ="https://images.app.goo.gl/UzbTyjzrgMckusjV7",
                        isFavourite =true,
                        available =true,
                        Category =_categoryMedicines.AllCategories.Last()},
                    new Medicine{
                        name ="Шампунь KALLOS Color",
                        shortDesc ="Шампунь для окрашенных и поврежденных волос, 1 л",
                        longDesc ="Назначение: для блеска, очищение, питание, тонизирование. Тип волос: окрашенные. Сделано в: Венгрия.",
                        img ="https://images.app.goo.gl/UzbTyjzrgMckusjV7",
                        isFavourite =true,
                        available =true,
                        Category =_categoryMedicines.AllCategories.Last()}
            };

            }
        }

        public IEnumerable<Medicine> getFavMeds { get; set; }

        public Medicine getObjectMed(int MedId)
        {
            throw new NotImplementedException();
        }
    }
}
