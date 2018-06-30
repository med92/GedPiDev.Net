using GedPiDev.Domain.Entities;
using GedPiDev.Service.Pattern;
using GedPiDev.Data.Infrastructure;
using GedPiDev.Service.Interfaces;

namespace GedPiDev.Service.Implementation
{
    public class WorkFlowService : Service<Workflow>, IWorkflowService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public WorkFlowService() : base(ut) { }
    }
}
