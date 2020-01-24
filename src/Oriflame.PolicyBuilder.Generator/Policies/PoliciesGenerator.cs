using System;
using System.Reflection;
using System.Threading.Tasks;
using Oriflame.PolicyBuilder.Generator.Operations;
using Oriflame.PolicyBuilder.Policies;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Definitions;

namespace Oriflame.PolicyBuilder.Generator.Policies
{
    public class PoliciesGenerator<TOperationPolicy, TResult> : Generator<TResult> 
        where TOperationPolicy : IOperationPolicy
        where TResult : class
    {
        private const string AllOperationsFileName = "AllOperations";

        private readonly IBuildersFactory<TOperationPolicy> _buildersFactory;

        public PoliciesGenerator(IFileExporter<TResult> fileExporter, IBuildersFactory<TOperationPolicy> buildersFactory, IOperationsProvider operationsProvider) : base(fileExporter, operationsProvider)
        {
            _buildersFactory = buildersFactory;
        }

        protected override void GenerateOutput(string outputDirectory, Assembly assembly)
        {
            var actionMethods = OperationsProvider.GetOperations(assembly);
            Parallel.ForEach(actionMethods, actionMethod => { GenerateFor(actionMethod, outputDirectory); });
            GenerateAllOperationsPolicy(outputDirectory, assembly);

            Console.WriteLine($"Policies for API has been written to {outputDirectory}");
        }

        private void GenerateAllOperationsPolicy(string outputDirectory, Assembly assembly)
        {
            var allOperationsMethodInfo = OperationsProvider.GetAllOperations(assembly);

            if (allOperationsMethodInfo == null)
            {
                return;
            }

            var allOperationsPolicy = CreatePolicyGenerator().Generate(allOperationsMethodInfo);
            FileExporter.ExportToFile(allOperationsPolicy, outputDirectory, AllOperationsFileName);
        }

        private PolicyGenerator<TOperationPolicy, TResult> CreatePolicyGenerator()
        {
            return new PolicyGenerator<TOperationPolicy, TResult>(_buildersFactory, GetCustomFixture());
        }

        protected void GenerateFor(MethodInfo actionMethod, string outputDirectory)
        {
            var fileName = OperationsProvider.GetOperationId(actionMethod);
            var operationPolicy = CreatePolicyGenerator().Generate(actionMethod);
            FileExporter.ExportToFile(operationPolicy, outputDirectory, fileName);
        }
    }
}
