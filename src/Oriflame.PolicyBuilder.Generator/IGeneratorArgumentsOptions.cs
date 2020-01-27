namespace Oriflame.PolicyBuilder.Generator
{
    public interface IGeneratorArgumentsOptions
    {
        /// <summary>
        /// Directory for storing exported metadata
        /// </summary>
        string OutputDirectory { get; set; }

        /// <summary>
        /// Name of the api from app settings
        /// </summary>
        string ApiName { get; set; }
    }
}