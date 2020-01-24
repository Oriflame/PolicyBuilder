using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Oriflame.PolicyBuilder.Generator.FixtureCustomization;

namespace Oriflame.PolicyBuilder.Generator
{
    public abstract class Generator<T> : IGenerator
    {
       protected readonly IFileExporter<T> FileExporter;

        protected Generator(IFileExporter<T> fileExporter)
        {
            FileExporter = fileExporter;
        }

        public virtual void Generate(string outputDirectory, Assembly assembly)
        {
            FileExporter.CleanDestination(outputDirectory);

            GenerateOutput(outputDirectory, assembly);
        }

        protected abstract void GenerateOutput(string outputDirectory, Assembly assembly);

        protected static IEnumerable<MethodInfo> GetActionMethods(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(method => !method.IsDefined(typeof(NonActionAttribute)));
        }

        protected static Fixture GetCustomFixture()
        {
            var fixture = new Fixture();
            fixture.Customize(new ApiControllerCustomization());
            return fixture;
        }
    }
}
