using MedShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Interfaces
{
    public interface IAllMedicines
    {
        IEnumerable<Medicine> Medicines { get; }
        IEnumerable<Medicine> getFavMeds { get;}
        Medicine getObjectMed(int MedId);
    }
}
