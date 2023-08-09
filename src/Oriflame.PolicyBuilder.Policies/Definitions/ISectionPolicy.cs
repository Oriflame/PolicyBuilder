namespace Oriflame.PolicyBuilder.Policies.Definitions
{
    public interface ISectionPolicy : IPolicy
    {
        void AddInnerPolicy(IPolicy policy);

        /// <summary>
        /// Hack for bug in Api Management - set-url needs to be defined as first policy in send-request and send-one-way-request policies
        /// </summary>
        void AddInnerPolicy(IPolicy policy, int priority);
    }
}