using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Kernel;
using Oriflame.PolicyBuilder.Policies.Builders;
using Oriflame.PolicyBuilder.Policies.Builders.Fluent.Sections;
using Oriflame.PolicyBuilder.Policies.Definitions;
using Oriflame.PolicyBuilder.Policies.Helpers;

namespace Oriflame.PolicyBuilder.Policies
{
    public class PolicyGenerator<TOperationPolicy, TResult> 
        where TOperationPolicy : IOperationPolicy
        where TResult : class
    {
        private readonly IBuildersFactory<TOperationPolicy> _buildersFactory;
        private readonly Fixture _fixture;

        public PolicyGenerator(IBuildersFactory<TOperationPolicy> buildersFactory, Fixture fixture = null)
        {
            _buildersFactory = buildersFactory;
            _fixture = fixture ?? new Fixture();

            // Set culture to invariant to avoid problems with decimal separator
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }

        public TResult Generate(MethodInfo method)
        {
            ActionContextHelper.Set(method);
            var operationPolicy = _buildersFactory.CreateOperationPolicy();
            var baseType = CreateBaseType(method, operationPolicy);
            var mockedArguments = GetArguments(method);
            try
            {
                method.Invoke(baseType, mockedArguments);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

            return operationPolicy.TransformTo<TResult>();
        }

        private object[] GetArguments(MethodBase methodInfo)
        {
            var methodParameters = methodInfo.GetParameters();
            var mockedParameters = methodParameters.Select(parameter => CreateDynamicType(parameter.ParameterType));
            return mockedParameters.ToArray();
        }

        private object CreateDynamicType(Type dynamicType)
        {
            return _fixture.Create(dynamicType, new SpecimenContext(_fixture));
        }

        private object CreateBaseType(MemberInfo method, TOperationPolicy operationPolicy)
        {
            _fixture.Customize(new AutoMoqCustomization());

            _fixture.Register(() => _buildersFactory.CreateInboundBuilder(operationPolicy));
            _fixture.Register(() => _buildersFactory.CreateBackendBuilder(operationPolicy));
            _fixture.Register(() => _buildersFactory.CreateOutboundBuilder(operationPolicy));
            _fixture.Register(() => _buildersFactory.CreateOnErrorBuilder(operationPolicy));
            _fixture.Register<IPolicyBuilder>(() => 
                new Builders.PolicyBuilder(
                    _fixture.Create<IInboundSectionPolicyBuilder>(), 
                    _fixture.Create<IBackendSectionPolicyBuilder>(), 
                    _fixture.Create<IOutboundSectionPolicyBuilder>(), 
                    _fixture.Create<IOnErrorSectionPolicyBuilder>(),
                    operationPolicy
                ));
            return _fixture.Create(method.ReflectedType, new SpecimenContext(_fixture));
        }
    }
}