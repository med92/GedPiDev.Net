using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Data.Entities
{
    public class Addresse
    {
        public string Pays { get; set; }
        public string Ville { get; set; }
        public int CodePostal { get; set; }
        public string Rue { get; set; }
    }
}
