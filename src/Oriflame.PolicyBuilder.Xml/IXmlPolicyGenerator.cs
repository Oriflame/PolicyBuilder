using System.Reflection;

namespace Oriflame.PolicyBuilder.Xml
{
    public interface IXmlPolicyGenerator
    {
        IXmlPolicy Generate(MethodInfo method);
    }
}