
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GedPiDev.Data.Entities
{
    public class Workflow
    {
        [Key]
        public string WorkFlowId { get; set; }

        public Workflow()
        {
            this.WorkFlowId = Guid.NewGuid().ToString();
        }
        public virtual List<Department> Steps { get; set; }
        public virtual Document Document { get; set; }
    }
}
