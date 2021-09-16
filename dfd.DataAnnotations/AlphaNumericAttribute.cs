using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace dfd.DataAnnotations
{
    /// <summary>
    /// Validates that the string contains only lowercase, letters  uppercase letters  or numbers
    /// </summary>
    public class AlphaNumericAttribute: ValidationAttribute
    {
    /// <summary>
    /// Validates that the string contains only lowercase, letters  uppercase letters  or numbers
    /// </summary>      
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
         string strValue = value as string;
        if (!string.IsNullOrEmpty(strValue))
        {
           var regex = new Regex("^[a-zA-Z0-9]*$");
           if (!regex.Match(strValue).Success){
                 return new ValidationResult($"{context.DisplayName} is not a valid alpha numeric.");
           }            
        }
        return ValidationResult.Success;      
    }

    }
}