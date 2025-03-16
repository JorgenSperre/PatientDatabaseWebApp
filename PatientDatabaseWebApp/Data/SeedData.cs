using Microsoft.EntityFrameworkCore;
using PatientDatabaseWebApp.DataModels;
using System.Collections.Generic;

namespace PatientDatabaseWebApp.Data
{
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

            // Drop and recreate the database
            if (true)
            {
                context.Database.EnsureDeleted();
            }
            context.Database.EnsureCreated();

            var conditionsList = new List<string>
            {
                "Hypertension", "Diabetes", "Asthma", "Heart Disease", "Arthritis",
                "Chronic Pain", "Depression", "Anxiety", "Obesity", "Cancer",
                "Allergies", "Migraine", "Osteoporosis", "COPD", "Stroke",
                "Alzheimer's", "Parkinson's", "Epilepsy", "Multiple Sclerosis", "Lupus",
                "COVID-19", "Vegan", "Hangry"
            };

            var firstNames = new List<string>
            {
                "John", "Jane", "Alice", "Bob", "Charlie", "Eve", "Frank", "Grace", "Hank", "Ivy",
                "Jack", "Kara", "Liam", "Mia", "Noah", "Olivia", "Paul", "Quinn", "Ryan", "Sophia",
                "Tom", "Uma", "Victor", "Wendy", "Xander", "Yara", "Zane", "Bella", "Carter", "Daisy",
                "Ethan", "Fiona", "George", "Holly", "Isaac", "Jasmine", "Kevin", "Luna", "Mason", "Nina"
            };

            var lastNames = new List<string>
            {
                "Doe", "Smith", "Johnson", "Brown", "Davis", "White", "Green", "Hall", "King", "Lee",
                "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "Harris", "Martin", "Thompson",
                "Garcia", "Martinez", "Robinson", "Clark", "Rodriguez", "Lewis", "Walker", "Young", "Allen", "Scott",
                "Adams", "Baker", "Gonzalez", "Nelson", "Carter", "Mitchell", "Perez", "Roberts", "Turner", "Phillips"
            };

            var patients = new List<Patient>();

            // Generate additional patients
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                var randomYear = random.Next(1950, 2010);
                var randomMonth = random.Next(1, 13);
                var randomDay = random.Next(1, DateTime.DaysInMonth(randomYear, randomMonth) + 1);
                var randomFirstName = firstNames[random.Next(firstNames.Count)];
                var randomLastName = lastNames[random.Next(lastNames.Count)];

                var patientConditions = new List<string>();
                int numberOfConditions = random.Next(0, 4); // 0 to 3 conditions
                for (int j = 0; j < numberOfConditions; j++)
                {
                    var randomCondition = conditionsList[random.Next(conditionsList.Count)];
                    if (!patientConditions.Contains(randomCondition))
                    {
                        patientConditions.Add(randomCondition);
                    }
                }

                patients.Add(new Patient
                {
                    Name = $"{randomFirstName} {randomLastName}",
                    DateOfBirth = new DateOnly(randomYear, randomMonth, randomDay),
                    Conditions = patientConditions.Any() ? patientConditions : null
                });
            }

            foreach (var patient in patients)
            {
                patient.FindAge();
            }

            context.Patient.AddRange(patients);
            context.SaveChanges();
        }
    }
}
