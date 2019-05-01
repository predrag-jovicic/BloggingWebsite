using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared_Library.ValidationAttributes
{
    public class TagsValidationAttribute : ValidationAttribute
    {
        private Regex rx;

        public TagsValidationAttribute()
        {
            rx = new Regex(@"^[\w\s\-]{3,100}$");
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
                foreach(string tag in tags)
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
