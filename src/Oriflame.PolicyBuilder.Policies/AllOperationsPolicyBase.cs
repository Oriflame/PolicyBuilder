using Oriflame.PolicyBuilder.Policies.Builders;

namespace Oriflame.PolicyBuilder.Policies
{
    public abstract class AllOperationsPolicyBase
    {
        protected readonly IPolicyBuilder PolicyBuilder;

        protected AllOperationsPolicyBase(IPolicyBuilder policyBuilder)
        {
            PolicyBuilder = policyBuilder;
        }

        public abstract void Create();
    }
}