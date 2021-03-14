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

            if (value is decimal)
            {
                if ((decimal)value <= 0)
                {
                    return new ValidationResult($"El valor {validationContext.DisplayName} debe ser superior a cero");
                }
            }
            else
            {
                if ((int)value <= 0)
                {
                    return new ValidationResult($"El valor {validationContext.DisplayName} debe ser superior a cero");
                }
            }

            return ValidationResult.Success;
        }
    }
}
