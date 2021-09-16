using System;
using System.ComponentModel.DataAnnotations;
namespace dfd.DataAnnotations
{
    
    

/// <summary>
/// Validates that a string is formatted as a proper guid.
/// </summary>
    public class GuidAttribute:ValidationAttribute 
    {        

        /// <summary>
        /// Validates that a string is formatted as a proper guid.
        /// </summary>

         protected override ValidationResult IsValid(object value, ValidationContext context)
         {
         string strValue = value as string;
        if (!string.IsNullOrEmpty(strValue))
        {
           
           try {
               var guid = new System.Guid(strValue);
           } catch (Exception) {               
               return new ValidationResult($"{context.DisplayName} does not have a valid guid.");
           }        
            
        }
        return ValidationResult.Success;      
    }
 


        
    }
}