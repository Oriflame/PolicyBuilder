using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Dependencies
{
    public class DependenciesPolicy : IDependencies, IOperationPolicy, ISectionPolicy
    {
        public IList<IDependency> Additional { get; }

        public IDependency Primary { get; }

        public DependenciesPolicy()
        {
            Additional = new List<IDependency>();
            Primary = new Dependency();
        }

        public void Add(IDependency dependency)
        {
            Additional.Add(dependency);
        }

        /// <summary>
        /// Allows you to transform Policy object to another object with specific policy representation  
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public TResult TransformTo<TResult>() where TResult : class
        {
            if (!(this is TResult))
            {
                throw new NotImplementedException();
            }
            
            return this as TResult;
        }

        public void AddInnerPolicy(IPolicy policy)
        {
        }
    }
}