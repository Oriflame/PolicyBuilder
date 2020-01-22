using CommandLine;
using Ori.Gateway.EndpointsMap;

namespace Ori.Gateway.Policies
{
    /// <summary>
    /// Export policies to XML
    /// </summary>
    [Verb("policies", HelpText = "Generate policies")]
    public class PoliciesOptions : IGeneratorArgumentsOptions
    {
        /// <summary>
        /// Directory for storing exported policies
        /// </summary>
        [Option("output", HelpText = "Output directory", Required = true)]
        public string OutputDirectory { get; set; }

        /// <summary>
        /// Name of the api from app settings
        /// </summary>
        [Option("api", HelpText = "ApiName", Required = true)]
        public string ApiName { get; set; }
    }
}
