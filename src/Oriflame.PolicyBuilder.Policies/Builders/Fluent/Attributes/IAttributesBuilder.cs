using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Policies.Builders.Fluent.Attributes
{
    public interface IAttributesBuilder
    {
        IDictionary<string, string> Create();
    }
}