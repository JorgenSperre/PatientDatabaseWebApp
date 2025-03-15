using System;
using System.ComponentModel.DataAnnotations;

namespace PatientDatabaseWebApp.Validation
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly DateOnly _minDate;

        public DateRangeAttribute(string minDate)
        {
            _minDate = DateOnly.Parse(minDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly dateValue)
            {
                DateOnly maxDate = DateOnly.FromDateTime(DateTime.Today);
                if (dateValue < _minDate || dateValue > maxDate)
                {
                    return new ValidationResult($"Date of birth must be between {_minDate} and {maxDate}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
