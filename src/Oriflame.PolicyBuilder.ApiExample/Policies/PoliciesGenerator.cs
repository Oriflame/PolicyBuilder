using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Ori.Gateway.Generator;
using Oriflame.PolicyBuilder.ApiExample.Settings;
using Oriflame.PolicyBuilder.Policies;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Definitions;


namespace Ori.Gateway.Policies
{
    public class PoliciesGenerator<TOperationPolicy, TResult> : Generator<TResult> 
        where TOperationPolicy : IOperationPolicy
        where TResult : class 
    {
        private readonly IBuildersFactory<TOperationPolicy> _buildersFactory;

        public PoliciesGenerator(IApiDescriptionGroupCollectionProvider apiDescriptionGroupCollectionProvider, IFileExporter<TResult> fileExporter, IOptionsMonitor<HostConfigs> hostConfigAccessor, IBuildersFactory<TOperationPolicy> buildersFactory) : base(apiDescriptionGroupCollectionProvider, fileExporter, hostConfigAccessor)
        {
            _buildersFactory = buildersFactory;
        }

        protected override void Generate(string outputDirectory, string apiName, IEnumerable<MethodInfo> actionMethods)
        {
            Parallel.ForEach(actionMethods, actionMethod => { GenerateFor(actionMethod, outputDirectory, GetApiFolder(apiName)); });
            GenerateAllOperationsPolicy(outputDirectory, GetApiAssembly(apiName), GetApiFolder(apiName));

            Console.WriteLine($"Policies for {apiName} API has been written to {outputDirectory}");
        }

        private void GenerateAllOperationsPolicy(string outputDirectory, Assembly assembly, string apiFolder)
        {
            var allOperationsMethodInfo = assembly
                .GetTypes().Single(type => typeof(AllOperationsPolicyBase).IsAssignableFrom(type))
                .GetMethod("Create");

             var allOperationsPolicy = CreatePolicyGenerator().Generate(allOperationsMethodInfo);
            FileExporter.ExportToFile(allOperationsPolicy, outputDirectory, "AllOperations");
        }

        private PolicyGenerator<TOperationPolicy, TResult> CreatePolicyGenerator()
        {
            return new PolicyGenerator<TOperationPolicy, TResult>(_buildersFactory, GetCustomFixture());
        }

        protected void GenerateFor(MethodInfo actionMethod, string outputDirectory, string groupName)
        {
            var operationId = GetOperationId(actionMethod);

            var operationPolicy = CreatePolicyGenerator().Generate(actionMethod);
            FileExporter.ExportToFile(operationPolicy, outputDirectory, operationId);
        }

        private static string GetOperationId(MethodInfo method)
        { 
            //TODO: Generate Operation Id
            throw new NotImplementedException();
        }
    }
}
