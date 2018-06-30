using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
    public class Attachement
    {
        public int Id { get; set; }
        public string attachement { get; set; }
        public Traceability traceability { get; set; }
    }
}
