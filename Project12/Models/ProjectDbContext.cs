using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project12.Models
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext() : base("FruitShop")
        {

        }

        public DbSet<Vegan> Vegans
        {
            get;
            set;
        }

        public DbSet<VeganType> VeganTypes
        {
            get;
            set;
        }

    }
}
