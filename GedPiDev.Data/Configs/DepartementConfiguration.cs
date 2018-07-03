using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using GedPiDev.Domain.Entities;

namespace GedPiDev.Data.Configurations
{
    public class DepartementConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartementConfiguration()
        {
            HasMany<ApplicationUser>(d => d.Users).
                WithRequired(u => u.department).
                HasForeignKey(u => u.DepartmentId);
        }
    }
}
