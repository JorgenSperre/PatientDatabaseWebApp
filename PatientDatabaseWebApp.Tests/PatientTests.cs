using System;
using System.ComponentModel.DataAnnotations;
using PatientDatabaseWebApp.DataModels;
using Xunit;

namespace PatientDatabaseWebApp.Tests
{
    public class PatientTests
    {
        #region FindAge() tests
        [Fact]
        public void FindAge_CorrectlyCalculatesAge_WhenBirthdayHasPassedThisYear()
        {
            // Arrange
            var patient = new Patient
            {
                DateOfBirth = new DateOnly(2000, 1, 1)
            };
            var expectedAge = DateOnly.FromDateTime(DateTime.Today).Year - 2000;

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
                DateOfBirth = new DateOnly(2000, DateTime.Today.Month + 1, 1)
            };
            var expectedAge = DateOnly.FromDateTime(DateTime.Today).Year - 2000 - 1;

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
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today)
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
                DateOfBirth = new DateOnly(2000, 2, 29) // Leap year birthday
            };

            // Act
            patient.FindAge();

            // Assert
            var today = DateOnly.FromDateTime(DateTime.Today);
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
        #endregion

        #region Validation and Property tests
        [Fact]
        public void Id_CanBeSetAndRetrieved()
        {
            // Arrange
            var patient = new Patient
            {
                Id = 1
            };

            // Act & Assert
            Assert.Equal(1, patient.Id);
        }

        [Fact]
        public void DateOfBirth_CanBeSetAndRetrieved()
        {
            // Arrange
            var dateOfBirth = new DateOnly(2000, 1, 1);
            var patient = new Patient
            {
                DateOfBirth = dateOfBirth
            };

            // Act & Assert
            Assert.Equal(dateOfBirth, patient.DateOfBirth);
        }

        [Fact]
        public void Name_ValidationFails_WhenNameIsTooShort()
        {
            // Arrange
            var patient = new Patient
            {
                Name = "A"
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void DateOfBirth_ValidationFails_WhenDateIsOutOfRange()
        {
            // Arrange
            var patient = new Patient
            {
                DateOfBirth = new DateOnly(1800, 1, 1)
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void Name_ValidationFails_WhenNameContainsInvalidCharacters()
        {
            // Arrange
            var patient = new Patient
            {
                Name = "John123"
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void Conditions_ValidationFails_WhenConditionsContainInvalidCharacters()
        {
            // Arrange
            var patient = new Patient
            {
                Conditions = "Diabetes123"
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void Conditions_ValidationFails_WhenConditionsExceedMaxLength()
        {
            // Arrange
            var patient = new Patient
            {
                Conditions = new string('a', 101) // Exceeds max length of 100
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void DateOfBirth_ValidationFails_WhenDateIsInTheFuture()
        {
            // Arrange
            var patient = new Patient
            {
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddDays(1)) // Future date
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void Name_ValidationFails_WhenNameExceedsMaxLength()
        {
            // Arrange
            var patient = new Patient
            {
                Name = new string('a', 61) // Exceeds max length of 60
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void Conditions_ValidationFails_WhenConditionsContainSpecialCharacters()
        {
            // Arrange
            var patient = new Patient
            {
                Conditions = "Diabetes@123" // Contains special character '@'
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void DateOfBirth_ValidationFails_WhenDateOfBirthIsNull()
        {
            // Arrange
            var patient = new Patient
            {
                DateOfBirth = default // Null value for DateOnly
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        [Fact]
        public void Name_ValidationFails_WhenNameIsNull()
        {
            // Arrange
            var patient = new Patient
            {
                Name = null
            };
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

        #endregion
    }
}
