using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Validators
{
    public class MinimumDateAttributeValidator : ValidationAttribute
    {
        public DateTime MinimumDate { get; set; }

        public string DefaultMessage { get; set; } = "Date should be newer than {0}";

        public MinimumDateAttributeValidator()
        {
            
        }

        public MinimumDateAttributeValidator(string date)
        {
            MinimumDate = Convert.ToDateTime(date);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) 
            { 
                DateTime date = (DateTime)value;

                if (date < MinimumDate)
                {
                    return new ValidationResult(String.Format(ErrorMessage ?? DefaultMessage, MinimumDate));
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
