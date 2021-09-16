using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace dfd.DataAnnotations.Tests.Model
{
    public class BasicObject : ValidatableConfig, IValidatableObject
    {
        [Required(AllowEmptyStrings =false)]
        public string RequiredField { get; set; }

        public string OptionalField { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OptionalField == "forcedError")
            {
                yield return new ValidationResult($"{nameof(OptionalField)} cannot be 'forcedError'");
            }
        }
    }
}
