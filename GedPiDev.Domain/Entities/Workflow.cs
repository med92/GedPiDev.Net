using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Domain.Entities
{
    public class Workflow
    {
        public int Id { get; set; }
        public string currentStep { get; set; } 
        public string nextStep { get; set; }
        public string previousStep { get; set; }
        public ICollection<string> steps { get; set; }
    }
}
