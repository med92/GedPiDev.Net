using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string departmentName { get; set; }
        public int numTel { get; set; }
        public string departmentEmail { get; set; }
        public Traceability traceability { get; set; }
        public virtual ICollection<ApplicationUser> Employee { get; set; }
    }
}
