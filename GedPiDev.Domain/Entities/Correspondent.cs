using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
    public class Correspondent
    {
        [Key]
        public string CorrespondentId { get; set; }
        public string NomCorrespondant { get; set; }
        [ForeignKey("Adresse")]
        public string AdresseId { get; set; }
        public virtual Adresse Adresse { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public int Fax { get; set; }


        public Correspondent()
        {
            this.CorrespondentId = Guid.NewGuid().ToString();
        }
    }
}
