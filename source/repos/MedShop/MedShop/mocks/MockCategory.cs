using MedShop.Interfaces;
using MedShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.mocks
{
    public class MockCategory : IMedicinesCategory
    {
        public IEnumerable<Category> AllCategories {
            get {
                return new List<Category> {
                new Category { categoryName="Медикаменты", desc="Таблетки, порошки, сиропы, кремы, гели и тд"},
                new Category { categoryName="Средства по уходу", desc="Декоративная косметика, кремы, шампуни, патчи тд"}
                };
            }
        }
    }
}
