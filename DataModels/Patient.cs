using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientDatabaseWebApp.DataModels
{
    public class Patient
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Conditions { get; set; }
    }
}
