using GedPiDev.Data;
using GedPiDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new GedPiDevContext())
            {

                Courrier A = new Courrier() { objet = "second email" };

                ctx.courriers.Add(A);
                ctx.SaveChanges();
            }



        }
    }
}
