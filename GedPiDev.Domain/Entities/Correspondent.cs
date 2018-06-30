using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
    public class Correspondent
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string adresse { get; set; }
        public int numTel { get; set; }
        public string email { get; set; }
        public string fax { get; set; }
        public Traceability traceability { get; set; }
    }
}
