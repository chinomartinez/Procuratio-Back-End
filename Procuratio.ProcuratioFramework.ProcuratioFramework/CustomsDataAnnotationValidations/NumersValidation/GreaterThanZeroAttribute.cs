using System.ComponentModel.DataAnnotations;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation
{
    /// <summary>
    /// Indicates if the current attribute is greater than zero.
    /// </summary>
    public class GreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null) { return ValidationResult.Success; }

            ValidationResult validationResult = new ValidationResult($"El valor {validationContext.DisplayName} debe ser superior a cero");

            if (value is decimal @decimal)
            {
                if (@decimal <= 0) { return validationResult; }
            }
            else if (value is float single)
            {
                if (single <= 0) { return validationResult; }
            }
            else if (value is float single1)
            {
                if (single1 <= 0) { return validationResult; }
            }
            else
            {
                if ((int)value <= 0) { return validationResult; }
            }

            return ValidationResult.Success;
        }
    }
}
