namespace Oriflame.PolicyBuilder.Generator
{
    public interface IFileExporter<in T>
    {
        /// <summary>
        /// Save metadata to file
        /// </summary>
        /// <param name="policy"></param>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        void ExportToFile(T policy, string filePath, string fileName);

        /// <summary>
        /// Clean destination directory
        /// </summary>
        /// <param name="filePath"></param>
        void CleanDestination(string filePath);
    }
}