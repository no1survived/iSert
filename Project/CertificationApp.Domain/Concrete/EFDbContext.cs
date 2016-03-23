using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertificationApp.Domain.Entities;

namespace CertificationApp.Domain.Concrete
{
    public class EFDbContext: DbContext
    {
        public DbSet<Report> Reports { get; set; }
    }
}
