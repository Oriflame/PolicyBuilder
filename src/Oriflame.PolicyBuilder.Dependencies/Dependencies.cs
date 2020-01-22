using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Dependencies
{
    public interface IDependencies
    {
        IList<IDependency> Additional { get; }
        
        IDependency Primary { get; }
    }
}