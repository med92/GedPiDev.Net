using GedPiDev.Data.Infrastructure;
using GedPiDev.Domain.Entities;
using GedPiDev.Service.Interfaces;
using GedPiDev.Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedPiDev.Service.Implementation
{
    public class AdresseService : Service<Adresse>, IAdresseService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public AdresseService() : base(ut) { }
    }
}
