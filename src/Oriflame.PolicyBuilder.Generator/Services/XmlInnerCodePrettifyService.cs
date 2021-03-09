using System.IO;
using System.Web;

namespace Oriflame.PolicyBuilder.Generator.Services
{
    /// <summary>
    /// Helper for prettifying the code inside XML
    /// </summary>
    public class XmlInnerCodePrettifyService : IPrettifyService
    {
        /// <summary>
        /// Prettifies the code inside XML
        /// </summary>
        /// <param name="path">File path</param>
        public void PrettifyFile(string path)
        {
            var fileContent = File.ReadAllText(path);
            var prettifiedContent = PrettifyContent(fileContent);
            File.WriteAllText(path, prettifiedContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        public string PrettifyContent(string xmlContent)
        {
            var content = xmlContent;
            UnescapeCodeBlocks(">@{", "}<", ref content); // Tags
            UnescapeCodeBlocks("=\"@{", "}\" ", ref content); // Attributes
            return content;
        }

        private void UnescapeCodeBlocks(string startSequence, string endSequence, ref string content)
        {
            var lastIndex = 0;
            while (true)
            {
                var startIndex = content.IndexOf(startSequence, lastIndex);
                if (startIndex < 0)
                {
                    break;
                }
                startIndex += startSequence.Length;

                var endIndex = content.IndexOf(endSequence, startIndex);
                if (endIndex < 0)
                {
                    break;
                }
                lastIndex = endIndex + 1;

                var length = endIndex - startIndex;
                var code = content.Substring(startIndex, length);
                content = content.Remove(startIndex, length);
                var unescapedCode = HttpUtility.HtmlDecode(code);
                content = content.Insert(startIndex, unescapedCode);
            }
        }
    }
}
