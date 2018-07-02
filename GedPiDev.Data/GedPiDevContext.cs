using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;
using GedPiDev.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using GedPiDev.Domain;

namespace GedPiDev.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
  public   class GedPiDevContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public GedPiDevContext() : 
            base("Name=MyContext")
        {
        }

        public DbSet<Courrier> courriers { get; set; }
        public DbSet<Department> departements { get; set; }
    }


    public class GedPiDevContextInitializer : DropCreateDatabaseIfModelChanges<GedPiDevContext>
    {
        protected override void Seed(GedPiDevContext context)
        {
            var listCategories = new Courrier() { ObjetCourrier = "email" }; 
          

            context.courriers.Add(listCategories);
            context.SaveChanges();
        }
    }



}
