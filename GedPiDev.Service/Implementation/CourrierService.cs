using GedPiDev.Data.Infrastructure;
using GedPiDev.Domain.Entities;
using GedPiDev.Service.Interfaces;
using GedPiDev.Service.Pattern;


namespace GedPiDev.Service.Implementation
{
    public class CourrierService : Service<Courrier>, ICourrierService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public CourrierService() : base(ut) { }
    }
}
