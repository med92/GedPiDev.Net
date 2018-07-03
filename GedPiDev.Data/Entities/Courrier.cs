using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Data.Entities
{
   public  class Courrier
    {
        [Key]
        public string CourrierId { get; set; }
        public Boolean Sense { get; set; }
        public Boolean Etat { get; set; }
        public string TypeCourrier { get; set; }
        public string ObjetCourrier { get; set; }
        public string Detail { get; set; }

        //Foreign Key
        [ForeignKey("Correspondent")]
        public string CorrespondantId { get; set; }

        //Navigation Properties
        public virtual List<Attachement> Fichiers { get; set; }
        public virtual Correspondent Correspondant { get; set; }

        public Courrier()
        {
            this.CourrierId = Guid.NewGuid().ToString();
        }
    }
}
