using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Shared_Library.ValidationAttributes
{
    public class StringListValidationAttribute : ValidationAttribute
    {
        private Regex rx;
        public StringListValidationAttribute(string regexp)
        {
            rx = new Regex(regexp);
        }
        public override string FormatErrorMessage(string name)
        {
            return name;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> tags = value as List<string>;
            if (tags == null)
                return new ValidationResult(FormatErrorMessage("Undefined list"));
            else
            {
                foreach (string tag in tags)
                {
                    if (!rx.IsMatch(tag))
                    {
                        return new ValidationResult(FormatErrorMessage("Incorrect string format"));
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}
