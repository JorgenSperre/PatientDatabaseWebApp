using Microsoft.EntityFrameworkCore;
using PatientDatabaseWebApp.DataModels;

namespace PatientDatabaseWebApp.Data;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new PatientDatabaseWebAppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<PatientDatabaseWebAppContext>>());

        if (context == null || context.Patient == null)
        {
            throw new NullReferenceException(
                "Null PatientDatabaseWebAppContext or Patient DbSet");
        }

        // Delete all existing patients                                                         For testing purposes. Remove later.
        context.Patient.RemoveRange(context.Patient);
        context.SaveChanges();

        if (context.Patient.Any())
        {
            return;
        }

        var patients = new List<Patient>
        {
            new Patient
            {
                Name = "John Doe",
                DateOfBirth = new DateOnly(1980, 1, 1),
                Conditions = "Hypertension",
            },
            new Patient
            {
                Name = "Jane Smith",
                DateOfBirth = new DateOnly(1990, 2, 2),
                Conditions = "Diabetes",
            },
            new Patient
            {
                Name = "Alice Johnson",
                DateOfBirth = new DateOnly(1975, 3, 3),
                Conditions = "Asthma",
            },
            new Patient
            {
                Name = "Bob Brown",
                DateOfBirth = new DateOnly(2000, 4, 4),
                Conditions = "None",
            },
            new Patient
            {
                Name = "Charlie Davis",
                DateOfBirth = new DateOnly(1965, 5, 5),
                Conditions = "Heart Disease",
            },
            new Patient
            {
                Name = "Eve White",
                DateOfBirth = new DateOnly(1985, 6, 6),
                Conditions = "Hangry",
            },
            new Patient
            {
                Name = "Frank Green",
                DateOfBirth = new DateOnly(1995, 7, 7),
                Conditions = "Vegan",
            }
        };

        foreach (var patient in patients)
        {
            patient.FindAge();
        }

        context.Patient.AddRange(patients);
        context.SaveChanges();
    }
}
