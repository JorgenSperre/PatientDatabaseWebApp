using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PatientDatabaseWebApp.Validation;

namespace PatientDatabaseWebApp.DataModels
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z()\s-]*$", ErrorMessage = "Name can only contain letters, spaces, parentheses, and hyphens")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DateRange("1900-01-01", ErrorMessage = "Date of birth must be between 01/01/1900 and today")]
        public DateOnly DateOfBirth { get; set; }
        public int Age { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z()\s-]*$", ErrorMessage = "Conditions can only contain letters, spaces, parentheses, and hyphens")]
        public string? Conditions { get; set; }

        public void FindAge()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            var years = today.Year - this.DateOfBirth.Year;

            if (this.DateOfBirth > today.AddYears(-years))
            {
                years--;
            }

            this.Age = years;
        }
    }
}