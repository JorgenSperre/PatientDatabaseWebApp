using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientDatabaseWebApp.DataModels;

namespace PatientDatabaseWebApp.Data
{
    public class PatientDatabaseWebAppContext : DbContext
    {
        public PatientDatabaseWebAppContext (DbContextOptions<PatientDatabaseWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<PatientDatabaseWebApp.DataModels.Patient> Patient { get; set; } = default!;
    }
}
