using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
    public class Department
    {
        [Key]
        public string DepartementId { get; set; }
        public string NomDepartement { get; set; }
        public string Responsable { get; set; }
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
