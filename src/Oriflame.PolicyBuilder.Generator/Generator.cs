using System.Reflection;
using AutoFixture;
using Oriflame.PolicyBuilder.Generator.FixtureCustomization;
using Oriflame.PolicyBuilder.Generator.Operations;

namespace Oriflame.PolicyBuilder.Generator
{
    public abstract class Generator<T> : IGenerator
    {
        protected readonly IFileExporter<T> FileExporter;

        protected readonly IOperationsProvider OperationsProvider;
        
        protected Generator(IFileExporter<T> fileExporter, IOperationsProvider operationsProvider)
        {
            FileExporter = fileExporter;
            OperationsProvider = operationsProvider;
        }

        public virtual void Generate(string outputDirectory, Assembly assembly)
        {
            FileExporter.CleanDestination(outputDirectory);

            GenerateOutput(outputDirectory, assembly);
        }

        protected abstract void GenerateOutput(string outputDirectory, Assembly assembly);

        protected static Fixture GetCustomFixture()
        {
            var fixture = new Fixture();
            fixture.Customize(new ApiControllerCustomization());
            return fixture;
        }
    }
}
