using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Data.Entities
{
    public class Attachement
    {
        public string FichierId { get; set; }
        public string NomFichier { get; set; }
        public string UrlFichier { get; set; }

        //Ce field est nullable (string)
        //un fichier peut appartenir a un document ou un courrier
        [ForeignKey("Courrier")]
        public string CourrierId { get; set; }


        public virtual Courrier Courrier { get; set; }
        public virtual Document Document { get; set; }

        public Attachement()
        {
            this.FichierId = Guid.NewGuid().ToString();
        }
    }
}

