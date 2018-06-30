using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        GedPiDevContext DataContext { get; }
    }

}
