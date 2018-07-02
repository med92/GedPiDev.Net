using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Data.Entities
{
    public class Traceability
    {
        public int Id { get; set; }
        public string creationUser { get; set; }
        public DateTime creationDate { get; set; }
        public String updateUser { get; set; }
        public DateTime updateDate { get; set; }

    }
}
