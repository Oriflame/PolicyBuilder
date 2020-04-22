# PolicyBuilder
This project is able to generate Policies for [Azure API Management](https://azure.microsoft.com/en-us/services/api-management/) from fluent interface written in .Net Core WebAPI application.

[![Build status](https://oriflame.visualstudio.com/Ori.Common/_apis/build/status/PolicyBuilder/Oriflame.PolicyBuilder-CI-CD?label=Release+build&branchName=master)](https://oriflame.visualstudio.com/Ori.Common/_build/latest?definitionId=2241&branchName=develop) [![Nuget](https://img.shields.io/nuget/v/Oriflame.PolicyBuilder.Generator)](https://www.nuget.org/packages/Oriflame.PolicyBuilder.Generator) [![Nuget (with prereleases)](https://img.shields.io/nuget/dt/Oriflame.PolicyBuilder.Generator?label=Downloads)](https://www.nuget.org/packages/Oriflame.PolicyBuilder.Generator)

- [PolicyBuilder](#policybuilder)
	- [Example](#example)
	- [How it works](#how-it-works)
		- [Benefits](#benefits)
	- [Getting Started](#getting-started)
	- [Tips & tricks](#tips--tricks)
		- [All operations policy](#all-operations-policy)
		- [Extensions](#extensions)
		- [Dynamic properties](#dynamic-properties)
		- [Release pipeline](#release-pipeline)
		- [Action method context in fluent builder](#action-method-context-in-fluent-builder)
	- [Development](#development)
		- [What’s missing?](#whats-missing)

Azure API Management is an implementation of API Gateway pattern on Azure. APIs are defined by API templates which consist of OpenAPI Specification (Frontend) and Policies (Backend). Policies are XML based rules which describes behavior of the endpoint for incoming requests. Each endpoint has its own policy and there is also policy applicable to all endpoints in the API.

Target of this project is to provide easy, programmatic and safe way how to write the policies.

## Example

Let’s have this simple policy (change url, change uri, cache result):
```xml
<policies>
	<inbound>
		<base />
		<set-backend-service base-url="https://contonso.com" />
		<rewrite-uri template="api/v1" />
	</inbound>
	<backend>
		<base />
	</backend>
	<outbound>
		<base />
		<cache-store duration="5" />
	</outbound>
	<on-error>
		<base />
	</on-error>
</policies>
```
You can describe it with PolicyBuilder like this:
```csharp
PolicyBuilder
	.Inbound(builder => builder
		.Base()
		.SetBackendService("https://contonso.com")
		.RewriteUri("api/v1")
		.Create())
	.Backend(builder => builder
		.Base()
		.Create())
	.Outbound(builder => builder
		.Base()
		.CacheStore(TimeSpan.FromSeconds(5))
		.Create())
	.OnError(builder => builder
		.Base()
		.Create());
```
And with using available extensions, you can simplify it like this:
```csharp
PolicyBuilder
	.Inbound(builder => builder
		.Base()
		.SetBackendAndRewriteUri("https://contonso.com", "api/v1"))
	.Backend()
	.OutboundWithCaching(TimeSpan.FromSeconds(5))
	.OnError();
```

## How it works

The basic idea is having a WebAPI project which represents the API Gateway. Each endpoint (action method) can have policy builder as its implementation. Policy builder itself describes policy through a fluent interface. The builder is resolved in runtime and XML policies are auto-generated into files. Generated policies can be stored in your repository or uploaded to an APIM instance.

Endpoint with policy builder can look like this:
```csharp
[HttpPost]
public void Post(string forecast)
{
	_policyBuilder.SetBackendAndRewriteUri("https://contonso.com", "api/v1");
}
```

### Benefits
- **Easy to start**
   
	It is more convenient for developers to describe an API endpoints in familiar IDE and .Net code base than in proprietary systems and code of Azure API Management. 

 - **Reusability**
   
	You can easily define your own methods or extensions which wraps common or repeated policy parts and maintain them on one place.

 - **Removing vendor lock**

	You can switch implementation of the PolicyBuilder and create your own API Gateway implementation

 - **Building release pipeline**

	Generated policies are stored in your repository and can be released to multiple instances of APIM (e.g. Test and Live)

- **Safe and testable**

	There is no way how to provide full testing of generated policies. But still the fluent interface and generator provides lot of building conditions and constraints to keep the output fully compatible with APIM.  

## Getting Started
1. Create your WebAPI project which will describe the API. You can use WebAPI template in VisualStudio. As an inspiration you can check our [example project](https://github.com/Oriflame/PolicyBuilder/tree/develop/src/Oriflame.PolicyBuilder.ApiExample)
2. Install PolicyBuilder generator [Nuget package](https://www.nuget.org/packages/Oriflame.PolicyBuilder.Generator)
   ```
	Install-Package Oriflame.PolicyBuilder.Generator
   ```
3. Register PolicyBuilder generator to your `ServiceCollection` in your `Startup.cs`
   ```csharp
    public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddPoliciesGenerator();
        }
   ```
4. Add Generator call
   	
	You can add this for example to `Program.cs` to generate your policy on application start.
	```csharp
	 public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var generator = host.Services.GetService(typeof(IGenerator)) as IGenerator;
            generator.Generate(@"APITemplates\ApiExample\policies", typeof(Program).Assembly);
            host.Run();
        }
	```
5. Inject `IPolicyBuilder` into your controller(s) to use PolicyBuilder and define your policies
6. Run your project (Ctrl+F5 in VS) to generate policies 
7. Policies can be uploaded to your APIM instance(s) using [APIM Rest API](https://docs.microsoft.com/en-us/rest/api/apimanagement/2019-01-01/policy/createorupdate)


## Tips & tricks
### All operations policy
Except endpoints you can define All operations policy which is applicable to all API endpoints. You have to simply inherit `AllOperationsPolicyBase` class. You can check our [All Operations example class](https://github.com/Oriflame/PolicyBuilder/blob/develop/src/Oriflame.PolicyBuilder.ApiExample/Policies/AllOperationsPolicy.cs)

### Extensions
For simplifying the builder code, you can use [predefined extensions](https://github.com/Oriflame/PolicyBuilder/tree/develop/src/Oriflame.PolicyBuilder.Policies/Builders/Extensions). Check [example](#example) how they could be useful. And of course you can simply create your own. 

### Dynamic properties
Sometimes you need to use C# snippets for getting variables etc. especially for complex policies. PolicyBuilder contains [small helpers](https://github.com/Oriflame/PolicyBuilder/tree/develop/src/Oriflame.PolicyBuilder.Xml/DynamicProperties) which allows you simply define those snippets.

*Example:*
```csharp
var backendUrlVariableName = "backendUrl";
PolicyBuilder
	.Inbound(builder => builder
		.Base()
		.SetVariable(backendUrlVariableName, NamedValue.Get("Backend"))
		.Create()
	)
	.Backend(builder => builder
		.SetBackendService(ContextVariable.GetAsString(backendUrlVariableName))
		.Base()
		.Create())
	.Outbound()
	.OnError();
```
```xml
<policies>
	<inbound>
		<base />
		<set-variable name="backendUrl" value="{{Backend}}" />
	</inbound>
	<backend>
		<set-backend-service base-url="@((string)context.Variables[&quot;backendUrl&quot;])" />
		<base />
	</backend>
	<outbound>
		<base />
	</outbound>
	<on-error>
		<base />
	</on-error>
</policies>
```
### Release pipeline
You can define easily your own release pipeline for whole API. You will need:
1. Add Swagger for generating OpenApi spec.
2. Connect your policies and OpenApi spec. by Operation Id by customizing `IOperationsProvider` 
3. Write a script for uploading whole API Template to API Management

You can read more about defining release process in [this article](https://developers.oriflame.com/2019/04/03/azure-api-management-release-process/)

### Action method context in fluent builder
If you need to access the controller method inside your implementation for a builder method, you can use `ActionContextHelper`. It stores `MethodInfo` in thread safe context.

This could be helpful when you need to get some a controller method attribute for example.

## Development
[![Build status](https://oriflame.visualstudio.com/Ori.Common/_apis/build/status/PolicyBuilder/Oriflame.PolicyBuilder-CI-CD?label=Prerelease+build&branchName=develop)](https://oriflame.visualstudio.com/Ori.Common/_build/latest?definitionId=2241&branchName=master) [![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Oriflame.PolicyBuilder.Generator)](https://www.nuget.org/packages/Oriflame.PolicyBuilder.Generator)

### What’s missing?
Policies in API Management are very rich functionality and not all combinations and options are currently available. Feel free to contribute and extend functionality of this project.