using System;
using System.Collections.Generic;
namespace GedPiDev.Data.Entities
{
    public class Department
    {
        public string DepartementId { get; set; }
        public string NomDepartement { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }


        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<Workflow> WorkFlows { get; set; }

        public Department()
        {
            this.DepartementId = Guid.NewGuid().ToString();
        }
    }
}
