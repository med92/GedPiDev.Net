using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;

namespace GedPiDev.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class GedPiDevContext : DbContext
    {
        public GedPiDevContext() : base()
        {

        }
    }
}
