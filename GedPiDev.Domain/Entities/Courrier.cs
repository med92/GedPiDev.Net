using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
   public  class Courrier
    {

        public int Id { get; set; }
        public String objet { get; set; }
        public string destinataire { get; set; }
    }
}
