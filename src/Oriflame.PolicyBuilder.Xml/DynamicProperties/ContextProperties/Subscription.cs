using System;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Subscription : ContextProperty
    {
        public Subscription(string path) : base(path)
        {
        }

        /// <summary>
        /// Type: <see cref="DateTime"/>
        /// </summary>
        public string CreatedDate => $"{Get()}.{nameof(CreatedDate)}";

        /// <summary>
        /// Type: <see cref="DateTime?"/>
        /// </summary>
        public string EndDate => $"{Get()}.{nameof(EndDate)}";

        public string Id => $"{Get()}.{nameof(Id)}";

        public string Key => $"{Get()}.{nameof(Key)}";

        public string Name => $"{Get()}.{nameof(Name)}";

        public string PrimaryKey => $"{Get()}.{nameof(PrimaryKey)}";

        public string SecondaryKey => $"{Get()}.{nameof(SecondaryKey)}";

        /// <summary>
        /// Type: <see cref="DateTime?"/>
        /// </summary>
        public string StartDate => $"{Get()}.{nameof(StartDate)}";
    }
}