using Project12.FruitShopDataSetTableAdapters;
using Project12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project12.Controllers
{
    internal class VeganTypeController
    {


        private ProjectDbContext DbContext = new ProjectDbContext();

        public VeganType Get(int id)
        {
                VeganType findedVeganType = DbContext.VeganTypes.Find(id);

            return findedVeganType;
        }

        public List<VeganType> GetAll()
        {
            return DbContext.VeganTypes.ToList();
        }


        public void Create(VeganType vegan)
        {
            DbContext.VeganTypes.Add(vegan);
            DbContext.SaveChanges();
        }

        public void Update(int id, VeganType vegan)
        {
            VeganType findedVeganType = DbContext.VeganTypes.Find(id);
            if (findedVeganType == null)
            {
                return;
            }
            findedVeganType.Name = vegan.Name;

            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            VeganType findedVeganType = DbContext.VeganTypes.Find(id);
            DbContext.VeganTypes.Remove(findedVeganType);
            DbContext.SaveChanges();
        }
    }
}

