using System.ComponentModel.DataAnnotations;
using dfd.DataAnnotations;


namespace dfd.DataAnnotations.Tests.Model
{
    internal class ObjectWithGuid:ValidatableConfig
    {
     
        [Guid]
        public string Guid  { get; set; }
    }
}