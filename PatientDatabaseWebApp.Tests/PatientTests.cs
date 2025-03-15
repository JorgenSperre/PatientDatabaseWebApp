using System;
using PatientDatabaseWebApp.DataModels;
using Xunit;

namespace PatientDatabaseWebApp.Tests
{
    public class PatientTests
    {
        [Fact]
        public void FindAge_CorrectlyCalculatesAge_WhenBirthdayHasPassedThisYear()
        {
            // Arrange
            var patient = new Patient
            {
                DateOfBirth = new DateTime(2000, 1, 1)
            };
            var expectedAge = DateTime.Today.Year - 2000;

            // Act
            patient.FindAge();

            // Assert
            Assert.Equal(expectedAge, patient.Age);
        }

        [Fact]
        public void FindAge_CorrectlyCalculatesAge_WhenBirthdayHasNotPassedThisYear()
        {
            // Arrange
            var patient = new Patient
            {
                DateOfBirth = new DateTime(2000, DateTime.Today.Month + 1, 1)
            };
            var expectedAge = DateTime.Today.Year - 2000 - 1;

            // Act
            patient.FindAge();

            // Assert
            Assert.Equal(expectedAge, patient.Age);
        }

        [Fact]
        public void FindAge_CorrectlyCalculatesAge_OnBirthday()
        {
            // Arrange
            var patient = new Patient
            {
                DateOfBirth = DateTime.Today
            };
            var expectedAge = 0;

            // Act
            patient.FindAge();

            // Assert
            Assert.Equal(expectedAge, patient.Age);
        }

        [Fact]
        public void FindAge_CorrectlyCalculatesAge_ForLeapYearBirthday()
        {
            // Arrange
            var patient = new Patient
            {
                DateOfBirth = new DateTime(2000, 2, 29) // Leap year birthday
            };

            // Act
            patient.FindAge();

            // Assert
            var today = DateTime.Today;
            var expectedAge = today.Year - 2000;
            if (today.Month < 2 || (today.Month == 2 && today.Day < 29))
            {
                expectedAge--;
            }

            Assert.Equal(expectedAge, patient.Age);
        }

        [Fact]
        public void Name_CanBeNull()
        {
            // Arrange
            var patient = new Patient
            {
                Name = null
            };

            // Act & Assert
            Assert.Null(patient.Name);
        }

        [Fact]
        public void Name_CanBeEmpty()
        {
            // Arrange
            var patient = new Patient
            {
                Name = string.Empty
            };

            // Act & Assert
            Assert.Equal(string.Empty, patient.Name);
        }

        [Fact]
        public void Conditions_CanBeValidString()
        {
            // Arrange
            var patient = new Patient
            {
                Conditions = "Diabetes"
            };

            // Act & Assert
            Assert.Equal("Diabetes", patient.Conditions);
        }

        [Fact]
        public void Conditions_CanBeNull()
        {
            // Arrange
            var patient = new Patient
            {
                Conditions = null
            };

            // Act & Assert
            Assert.Null(patient.Conditions);
        }

        [Fact]
        public void Conditions_CanBeEmpty()
        {
            // Arrange
            var patient = new Patient
            {
                Conditions = string.Empty
            };

            // Act & Assert
            Assert.Equal(string.Empty, patient.Conditions);
        }
    }
}
