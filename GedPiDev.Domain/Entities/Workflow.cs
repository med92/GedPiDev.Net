
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GedPiDev.Domain.Entities
{
    public class Workflow
    {
        [Key]
        public string WorkflowId { get; set; }

        public Workflow()
        {
            this.WorkflowId = Guid.NewGuid().ToString();
        }

        public virtual List<Department> Steps { get; set; }
    }
}
