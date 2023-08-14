using System;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Subscription : ContextProperty, ISubscription
    {
        public Subscription(string path) : base(path)
        {
        }

        /// <summary>
        /// Type: <see cref="DateTime"/>
        /// </summary>
        public string CreatedDate => $"{GetPropertyPath()}.{nameof(CreatedDate)}";

        /// <summary>
        /// Type: <see cref="DateTime?"/>
        /// </summary>
        public string EndDate => $"{GetPropertyPath()}.{nameof(EndDate)}";

        public string Id => $"{GetPropertyPath()}.{nameof(Id)}";

        public string Key => $"{GetPropertyPath()}.{nameof(Key)}";

        public string Name => $"{GetPropertyPath()}.{nameof(Name)}";

        public string PrimaryKey => $"{GetPropertyPath()}.{nameof(PrimaryKey)}";

        public string SecondaryKey => $"{GetPropertyPath()}.{nameof(SecondaryKey)}";

        /// <summary>
        /// Type: <see cref="DateTime?"/>
        /// </summary>
        public string StartDate => $"{GetPropertyPath()}.{nameof(StartDate)}";
    }
}