using GedPiDev.Data.Infrastructure;
using GedPiDev.Service.Interfaces;
using GedPiDev.Service.Pattern;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Service.Implementation
{
    public class IdentityUserRoleService : Service<IdentityUserRole>, IIDentityUserRoleService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public IdentityUserRoleService() : base(ut) { }
    }
}
