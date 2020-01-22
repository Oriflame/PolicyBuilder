using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ori.Gateway.Generator;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Xml;
using Oriflame.PolicyBuilder.Xml.Definitions.Sections;


namespace Ori.Gateway.Policies
{
    public class PoliciesStartup : StartupBase
    {
        public PoliciesStartup() : base()
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddSingleton<IGenerator, PoliciesGenerator<XmlOperationPolicy, IXmlPolicy>>();
            services.AddSingleton<IFileExporter<IXmlPolicy>, PolicyXmlExporter>();
            services.AddSingleton<IBuildersFactory<XmlOperationPolicy>, XmlPolicyBuildersFactory>();
        }

        public override void Configure(IApplicationBuilder app)
        {
        }
    }
}