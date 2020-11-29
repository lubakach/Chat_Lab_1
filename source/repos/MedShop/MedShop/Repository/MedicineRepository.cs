using Microsoft.EntityFrameworkCore;
using MedShop.Interfaces;
using MedShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Repository
{
    public class MedicineRepository : IAllMedicines
    {
        private readonly AppDBContent appDBContent;
        public MedicineRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Medicine> Medicines => appDBContent.Medicine.Include(c=>c.Category);

        public IEnumerable<Medicine> getFavMeds => appDBContent.Medicine.Where(p => p.isFavourite).Include(c => c.Category);

        public Medicine getObjectMed(int MedId) => appDBContent.Medicine.FirstOrDefault(p => p.id == MedId);
    }
}
