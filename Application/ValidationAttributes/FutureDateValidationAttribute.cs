using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ValidationAttributes
{
    public class FutureDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;
            DateTime dateTime = (DateTime)value;
            if (dateTime != null)
            {
                if (dateTime > DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(FormatErrorMessage("Datetime you entered is not in the future."));
                }
            }
            else
                return new ValidationResult(FormatErrorMessage("Date you entered is not valid."));
        }
    }
}
