using System.Collections.Generic;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class User : ContextProperty
    {
        public User(string path) : base(path)
        {
            Identities = new UserIdentities($"{Get()}.{nameof(Identities)}");
        }

        public string Email => $"{Get()}.{nameof(Email)}";

        public string FirstName => $"{Get()}.{nameof(FirstName)}";

        /// <summary>
        /// IEnumerable<IGroup>
        /// </summary>
        public Groups Groups;

        public string Id => $"{Get()}.{nameof(Id)}";

        /// <summary>
        /// IEnumerable<IUserIdentity>
        /// </summary>
        public UserIdentities Identities;

        public string LastName => $"{Get()}.{nameof(LastName)}";

        public string Note => $"{Get()}.{nameof(Note)}";

        /// <summary>
        /// Type <see cref="DateTime"/>
        /// </summary>
        public string RegistrationDate => $"{Get()}.{nameof(RegistrationDate)}";
    }
}