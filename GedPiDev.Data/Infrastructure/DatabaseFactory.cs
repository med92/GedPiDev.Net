using GedPidev.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GedPiDev.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private GedPiDevContext dataContext;
        public GedPiDevContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new GedPiDevContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
