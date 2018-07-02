using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
   public class Document
    {
        //Id document est l'id du fichier (relation 1 to 0-1)
        [Key]
        [ForeignKey("Attachement")]  //reference a la variable de navigation
        public string DocumentId { get; set; }
        public string NomDocument { get; set; }
        public Boolean Etat { get; set; }
        public int CurrentStat { get; set; }
        public string DateCreation { get; set; }

        //ForeignKey
        //User created the document
        public string ApplicationUserId { get; set; }
        //Workflow for the document
        [ForeignKey("Workflow")]
        public string WorkflowId { get; set; }


        public virtual Attachement Attachement { get; set; }
        public virtual ApplicationUser CreationUser { get; set; }
        public virtual Workflow Workflow { get; set; }
    }
}
