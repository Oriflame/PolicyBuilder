using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IBuilderReadOnlyDictionary<TValue>
    {
        string Keys { get; }

        string Values { get; }

        string Count { get; }

        TValue this[string key] { get; }

        string TryGetValue(string key, string outValue);

        string ContainsKey(string key);
    }
}