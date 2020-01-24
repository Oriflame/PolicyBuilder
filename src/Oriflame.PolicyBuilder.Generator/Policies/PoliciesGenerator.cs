using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Oriflame.PolicyBuilder.Policies;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Generator.Policies
{
    public class PoliciesGenerator<TOperationPolicy, TResult> : Generator<TResult> 
        where TOperationPolicy : IOperationPolicy
        where TResult : class 
    {
        private readonly IBuildersFactory<TOperationPolicy> _buildersFactory;

        public PoliciesGenerator(IFileExporter<TResult> fileExporter, IBuildersFactory<TOperationPolicy> buildersFactory) : base(fileExporter)
        {
            _buildersFactory = buildersFactory;
        }

        protected override void GenerateOutput(string outputDirectory, Assembly assembly)
        {
            Parallel.ForEach(GetActionMethods(assembly), actionMethod => { GenerateFor(actionMethod, outputDirectory); });
            GenerateAllOperationsPolicy(outputDirectory, assembly);

            Console.WriteLine($"Policies for API has been written to {outputDirectory}");
        }

        private void GenerateAllOperationsPolicy(string outputDirectory, Assembly assembly)
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

        protected void GenerateFor(MethodInfo actionMethod, string outputDirectory)
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
