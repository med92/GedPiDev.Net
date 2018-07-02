using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Data.Entities
{
    public class Correspondent
    {
        [Key]
        public string CorrespondantId { get; set; }
        public string NomCorrespondant { get; set; }
        public Addresse Addresse { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public int Fax { get; set; }


        public Correspondent()
        {
            this.CorrespondantId = Guid.NewGuid().ToString();
        }
    }
}

