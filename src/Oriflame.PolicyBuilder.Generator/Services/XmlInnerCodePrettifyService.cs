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
        public string Prettify(string xmlContent)
        {
            var content = xmlContent;
            DecodeCodeBlocks(">@{", "}<", ref content); // Method in tags
            DecodeCodeBlocks("=\"@{", "}\"", ref content); // Method in attributes
            DecodeCodeBlocks(">@(", ")<", ref content); // Expression in tags
            DecodeCodeBlocks("=\"@(", ")\"", ref content); // Expression in attributes
            return content;
        }

        /// <summary>
        /// Finds code block in XML and decodes the HTML-encoded characters
        /// </summary>
        /// <param name="startSequence"></param>
        /// <param name="endSequence"></param>
        /// <param name="content"></param>
        private void DecodeCodeBlocks(string startSequence, string endSequence, ref string content)
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
                lastIndex = startIndex;

                var length = endIndex - startIndex;
                var code = content.Substring(startIndex, length);
                content = content.Remove(startIndex, length);
                var unescapedCode = HttpUtility.HtmlDecode(code);
                content = content.Insert(startIndex, unescapedCode);
            }
        }
    }
}
