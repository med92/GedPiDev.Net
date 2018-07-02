using GedPiDev.Domain;
using GedPiDev.Data;

namespace GedPiDev.Service
{
    public class DbContextFactory
    {
        public static IDbContext Create()
        {
            return new GedPiDevContext();
        }
    }
}
