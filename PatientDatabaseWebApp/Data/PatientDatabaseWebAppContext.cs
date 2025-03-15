using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientDatabaseWebApp.DataModels;

namespace PatientDatabaseWebApp.Data
{
    public class PatientDatabaseWebAppContext : DbContext
    {
        public PatientDatabaseWebAppContext(DbContextOptions<PatientDatabaseWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<PatientDatabaseWebApp.DataModels.Patient> Patient { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var splitStringConverter = new ValueConverter<List<string>, string>(
                v => string.Join(";", v),
                v => v.Split(new[] { ';' }, StringSplitOptions.None).ToList());

            modelBuilder.Entity<Patient>()
                .Property(p => p.Conditions)
                .HasConversion(splitStringConverter);
        }
    }
}
