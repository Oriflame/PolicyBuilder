﻿using Microsoft.Extensions.DependencyInjection;
using Oriflame.PolicyBuilder.Generator.Operations;
using Oriflame.PolicyBuilder.Generator.Services;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Xml;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;

namespace Oriflame.PolicyBuilder.Generator.Policies
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoliciesGenerator(this IServiceCollection services)
        {
            services.AddSingleton<IGenerator, PoliciesGenerator<XmlOperationPolicy, IXmlPolicy>>();
            services.AddSingleton<IPrettifyService, XmlInnerCodePrettifyService>();
            services.AddSingleton<IFileExporter<IXmlPolicy>, PolicyXmlExporter>();
            services.AddSingleton<IBuildersFactory<XmlOperationPolicy>, XmlPolicyBuildersFactory>();
            services.AddSingleton<IOperationsProvider, OperationsProvider>();
            services.AddSingleton<IPolicyBuilder, DummyPolicyBuilder>();
            return services;
        }
    }
}