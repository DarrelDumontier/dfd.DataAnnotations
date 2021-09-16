namespace dfd.DataAnnotations
{

     /// <summary>
        /// Provides methods to validate config files and display user friendly messages easier.
        /// </summary>
    public interface IValidatableConfig
    {

         /// <summary>
        /// Throws an easy to read ValidationException if any of the validation rules defined in the data annotation properties or the Validate method fail.
        /// </summary>
       /// <param name="configFileDescription">The name or short description of the config file, which will be included in the error message so that the user can understand which config had the error.</param>
        void ValidateAndThrowValidationException(string configFileDescription = "the config file");
    }
}