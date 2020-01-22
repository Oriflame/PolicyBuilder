namespace Oriflame.PolicyBuilder.Policies.Definitions
{
    public interface ISectionPolicy : IPolicy
    {
       void AddInnerPolicy(IPolicy policy);
    }
}