using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientDatabaseWebApp.DataModels
{
    public class Patient
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        public DateOnly DateOfBirth { get; set; }
        public int Age { get; set; }

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
