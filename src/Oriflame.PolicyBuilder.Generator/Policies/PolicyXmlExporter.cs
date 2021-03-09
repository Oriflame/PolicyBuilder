using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Oriflame.PolicyBuilder.Xml;

namespace Oriflame.PolicyBuilder.Generator.Policies
{
    public class PolicyXmlExporter : IFileExporter<IXmlPolicy>
    {
        private static string LineBreak = "\r\n";
        private static Encoding _encoding = Encoding.Unicode;

        private readonly IPrettifyService _prettifyService;

        public PolicyXmlExporter(IPrettifyService prettifyService)
        {
            _prettifyService = prettifyService;
        }

        public void ExportToFile(IXmlPolicy policy, string filePath, string fileName)
        {
            var xml = policy.GetXml();

            CreateDirectory(filePath);

            var path = Path.Combine(filePath, $"{fileName}.xml");

            var xmlDocument = new XDocument(xml);
            SaveToFile(xmlDocument, path);
        }

        public void CleanDestination(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath, true);
            }
        }

        private void SaveToFile(XDocument xmlDocument, string path)
        {
            var xws = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                IndentChars = "\t",
                Encoding = _encoding,
                NewLineChars = LineBreak,
            };
            using (var xw = XmlWriter.Create(path, xws))
            {
                xmlDocument.Save(xw);
            }

            _prettifyService.PrettifyFile(path);

            File.AppendAllText(path, LineBreak, _encoding);
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