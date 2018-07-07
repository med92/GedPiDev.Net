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
        [Key]
        [ForeignKey("Attachement")]  //reference a la variable de navigation
        public string DocumentId { get; set; }
        public string NomDocument { get; set; }
        public Boolean Etat { get; set; }
        public int CurrentStat { get; set; }
        public string DateCreation { get; set; }

        
        //Workflow for the document
        
        public string WorkflowId { get; set; }


        public virtual Attachement Attachement { get; set; }
        public virtual string CreationUser { get; set; }
        public string UdateUser { get; set; }
        public string UpdateDate { get; set; }
    }
}
