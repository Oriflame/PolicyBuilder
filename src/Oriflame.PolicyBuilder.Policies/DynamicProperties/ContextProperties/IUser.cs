namespace Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties
{
    public interface IUser : IContextProperty
    {
        string Email { get; }
        string FirstName { get; }
        IGroups Groups { get; }
        string Id { get; }
        IUserIdentities Identities { get; }
        string LastName { get; }
        string Note { get; }
        string RegistrationDate { get; }
    }
}