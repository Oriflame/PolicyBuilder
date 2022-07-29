using System;
using System.Collections.Generic;
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

            DecodeCodeBlocks(KeyValuePair.Create("template", "liquid"), ref content); // Liquid template in tags
            
            return content;
        }

        /// <summary>
        /// Finds code block in XML and decodes the HTML-encoded characters
        /// </summary>
        /// <param name="startSequence"></param>
        /// <param name="endSequence"></param>
        /// <param name="content"></param>
        private static void DecodeCodeBlocks(string startSequence, string endSequence, ref string content)
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
                lastIndex = endIndex;

                DecodeCodeBlock(startIndex, endIndex, ref content);
            }
        }

        /// <summary>
        /// Finds code block in XML by attribute data provided and decodes the HTML-encoded characters
        /// </summary>
        /// <param name="attributeData"></param>
        /// <param name="content"></param>
        private static void DecodeCodeBlocks(KeyValuePair<string, string> attributeData, ref string content)
        {
            var attribute = $"{attributeData.Key}=\"{attributeData.Value}\"";
            var lastIndex = 0;
            while (true)
            {
                var attributeIndex = content.IndexOf(attribute, lastIndex, StringComparison.InvariantCultureIgnoreCase);
                if (attributeIndex < 0)
                {
                    break;
                }
                attributeIndex += attribute.Length;

                var startIndex = content.IndexOf(">", attributeIndex);
                if (startIndex < 0)
                {
                    break;
                }

                var endIndex = content.IndexOf("</", startIndex);
                if (endIndex < 0)
                {
                    break;
                }
                lastIndex = endIndex;

                DecodeCodeBlock(startIndex, endIndex, ref content);
            }
        }

        private static void DecodeCodeBlock(int startIndex, int endIndex, ref string content)
        {
            var length = endIndex - startIndex;
            var code = content.Substring(startIndex, length);
            content = content.Remove(startIndex, length);
            var unescapedCode = HttpUtility.HtmlDecode(code);
            content = content.Insert(startIndex, unescapedCode);
        }
    }
}
