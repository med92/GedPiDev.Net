using GedPiDev.Data.Infrastructure;
using GedPiDev.Domain.Entities;
using GedPiDev.Service.Pattern;


namespace GedPiDev.Service.Implementation
{
    public class CourrierService : Service<Department>, IDepartmentService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public CourrierService() : base(ut) { }
    }
}
