using MedShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Interfaces
{
    public interface IMedicinesCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
