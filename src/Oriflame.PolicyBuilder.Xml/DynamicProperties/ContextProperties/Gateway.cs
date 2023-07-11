﻿using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class Gateway : ContextProperty, IGateway
    {
        public Gateway(string path) : base(path)
        {
        }

        public string Id => $"{Get()}.{nameof(Id)}";

        public string InstanceId => $"{Get()}.{nameof(InstanceId)}";

        /// <summary>
        /// Type: <see cref="bool"/>
        /// </summary>
        public string IsManaged => $"{Get()}.{nameof(IsManaged)}";
    }
}