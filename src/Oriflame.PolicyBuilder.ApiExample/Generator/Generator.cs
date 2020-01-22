using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Ori.Gateway.Generator.FixtureCustomization;
using Oriflame.PolicyBuilder.ApiExample.Settings;

namespace Ori.Gateway.Generator
{
    public abstract class Generator<T> : IGenerator
    {
        protected readonly IApiDescriptionGroupCollectionProvider ApiDescriptionGroupCollectionProvider;

        protected readonly IFileExporter<T> FileExporter;

        protected readonly IOptionsMonitor<HostConfigs> HostConfigAccessor;

        protected Generator(IApiDescriptionGroupCollectionProvider apiDescriptionGroupCollectionProvider, IFileExporter<T> fileExporter, IOptionsMonitor<HostConfigs> hostConfigAccessor)
        {
            ApiDescriptionGroupCollectionProvider = apiDescriptionGroupCollectionProvider;
            FileExporter = fileExporter;
            HostConfigAccessor = hostConfigAccessor;
        }

        public virtual void Generate(string outputDirectory, string apiName)
        {
            
            var assembly = GetApiAssembly(apiName);

            var actionMethods = GetActionMethods(assembly);
            
            FileExporter.CleanDestination(outputDirectory);

            Generate(outputDirectory, apiName, actionMethods);
        }

        protected abstract void Generate(string outputDirectory, string apiName, IEnumerable<MethodInfo> actionMethods);

        protected static IEnumerable<MethodInfo> GetActionMethods(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(method => !method.IsDefined(typeof(NonActionAttribute)));
        }

        protected Assembly GetApiAssembly(string apiName)
        {
            throw new NotImplementedException();
        }

        protected string GetApiFolder(string apiName)
        {
            return HostConfigAccessor.CurrentValue.HostsCollection.First(h => h.ApiName == apiName).Folder;
        }

        protected static Fixture GetCustomFixture()
        {
            var fixture = new Fixture();
            fixture.Customize(new ApiControllerCustomization());
            return fixture;
        }
    }
}
