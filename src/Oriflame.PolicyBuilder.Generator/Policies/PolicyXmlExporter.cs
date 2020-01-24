using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Xml;

namespace Oriflame.PolicyBuilder.Generator.Policies
{
    public class PolicyXmlExporter : IFileExporter<IXmlPolicy>
    {
        private const string LineBreak = "\r\n";
        private readonly Encoding _encoding = Encoding.Unicode;

        public void ExportToFile(IXmlPolicy policy, string filePath, string fileName)
        {
            var xml = policy.GetXml();

            CreateDirectory(filePath);

            var file = Path.Combine(filePath, $"{fileName}.xml");

            var xmlDocument = new XDocument(xml);
            var xws = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true, IndentChars = "\t", Encoding = _encoding, NewLineChars = LineBreak };
            using (var xw = XmlWriter.Create(file, xws))
            {
                xmlDocument.Save(xw);
            }
            File.AppendAllText(file, LineBreak, _encoding);
            
        }

        public void CleanDestination(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath, true);
            }
        }

        private static void CreateDirectory(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }
    }
}