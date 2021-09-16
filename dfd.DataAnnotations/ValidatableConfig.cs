using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace dfd.DataAnnotations
{
      /// <summary>
        /// Provides methods to validate config files and display user friendly messages easier. To use, inherit this object with a class representing config settings.
        /// </summary>
        /// <inheritdoc />

    public  class ValidatableConfig: IValidatableConfig
    {
              
        
        
        /// <inheritdoc />

        public void ValidateAndThrowValidationException(string configFileDescription = "the config file")
        {
          var context = new ValidationContext(this, serviceProvider: null, items: null);
             var validationErrors = new List<ValidationResult>();
             Validator.TryValidateObject(this, context, validationErrors, true);      
            if (validationErrors.Any())
            {
                var message = $"Found {validationErrors.Count} configuration error(s) in {configFileDescription}.\r\n ";
                foreach(var error in validationErrors){
                    message += error.ErrorMessage + "\r\n"; 
                }
                throw new ValidationException(message);
            }
        }

             

       
    }
}