using System.Reflection;

namespace Oriflame.PolicyBuilder.Generator
{
    /// <summary>
    /// Common generator
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Generate metadata for selected API
        /// </summary>
        void Generate(string outputDirectory, Assembly assembly);
    }
}