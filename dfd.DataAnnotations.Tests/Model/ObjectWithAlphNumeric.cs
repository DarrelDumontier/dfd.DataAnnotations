using System.ComponentModel.DataAnnotations;
using dfd.DataAnnotations;


namespace dfd.DataAnnotations.Tests.Model
{
    internal class ObjectWithAlphNumeric:ValidatableConfig
    {
     
        [AlphaNumeric]
        public string Value  { get; set; }
    }
}