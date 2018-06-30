using GedPiDev.Domain.Entities;
using GedPiDev.Service.Pattern;
using GedPiDev.Data.Infrastructure;
using GedPiDev.Service.Interfaces;

namespace GedPiDev.Service.Implementation
{
    public class AttachmentService : Service<Attachement>, IAttachementService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public AttachmentService() : base(ut) { }
    }
}
