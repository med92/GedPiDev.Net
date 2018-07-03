using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
    public class Adresse
    {
        [Key, ForeignKey("Correspondent")]
        public string AdresseId { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
        public int CodePostal { get; set; }
        public string Rue { get; set; }
        public virtual Correspondent Correspondent { get; set; }
    }
}