using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;
using GedPiDev.Domain.Entities;

namespace GedPiDev.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
  public   class GedPiDevContext : DbContext
    {
        public GedPiDevContext() : base("Name=MyContext")
        {
            Database.SetInitializer<GedPiDevContext>(new GedPiDevContextInitializer());
        }

        public DbSet<Courrier> courriers { get; set; }
    }


    public class GedPiDevContextInitializer : DropCreateDatabaseIfModelChanges<GedPiDevContext>
    {
        protected override void Seed(GedPiDevContext context)
        {
            var listCategories = new Courrier() { objet = "email" }; 
          

            context.courriers.Add(listCategories);
            context.SaveChanges();
        }
    }



}
