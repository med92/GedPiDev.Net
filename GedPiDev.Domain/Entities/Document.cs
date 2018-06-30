using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
   public class Document
    {
        public int Id { get; set; }
        public String docName { get; set; }
        public DocState status { get; set; }
        public Attachement attachement { get; set; }
        public virtual Workflow docWorkFlow { get; set; }
        public Traceability traceability { get; set; }
    }
}
