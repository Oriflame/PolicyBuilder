namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface ISubscription : IContextProperty
    {
        string CreatedDate { get; }
        string EndDate { get; }
        string Id { get; }
        string Key { get; }
        string Name { get; }
        string PrimaryKey { get; }
        string SecondaryKey { get; }
        string StartDate { get; }
    }
}