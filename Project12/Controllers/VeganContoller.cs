using Project12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project12.Controllers
{
    internal class VeganContoller
    {
        private ProjectDbContext DbContext = new ProjectDbContext();

        public Vegan Get(int id)
        {
            Vegan findedVegan = DbContext.Vegans.Find(id);
            if (findedVegan != null)
            {
                DbContext.Entry(findedVegan).Reference(x => x.VeganTypes).Load();
            }
            return findedVegan;
        }

        public List<Vegan> GetAll()
        {
            return DbContext.Vegans.Include("VeganTypes").ToList();
        }


        public void Create(Vegan vegan)
        {
            DbContext.Vegans.Add(vegan);
            DbContext.SaveChanges();
        }

        public void Update(int id, Vegan vegan)
        {
            Vegan findedVegan = DbContext.Vegans.Find(id);
            if (findedVegan == null)
            {
                return;
            }
            findedVegan.Price = vegan.Price;
            findedVegan.Name = vegan.Name;
            findedVegan.VeganTypes = vegan.VeganTypes;
            findedVegan.Description = vegan.Description;
            findedVegan.VeganTypeId= vegan.VeganTypeId;
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Vegan findedVegan = DbContext.Vegans.Find(id);
            DbContext.Vegans.Remove(findedVegan);
            DbContext.SaveChanges();
        }
    }
}

