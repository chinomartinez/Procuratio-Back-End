using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation
{
    public class ItCantBeNegativeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null) { return ValidationResult.Success; }

            ValidationResult validationResult = new ValidationResult($"El valor {validationContext.DisplayName} no puede ser negativo");

            if (value is decimal @decimal)
            {
                if (@decimal < 0) { return validationResult; }
            }
            else if (value is float single)
            {
                if (single < 0) { return validationResult; }
            }
            else if (value is float single1)
            {
                if (single1 < 0) { return validationResult; }
            }
            else
            {
                if ((int)value <= 0) { return validationResult; }
            }

            return ValidationResult.Success;
        }
    }
}
