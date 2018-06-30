using GedPiDev.Domain.Entities;
using GedPiDev.Service.Pattern;
using GedPiDev.Data.Infrastructure;

namespace GedPiDev.Service
{
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public DepartmentService() : base(ut) { }
    }
}
