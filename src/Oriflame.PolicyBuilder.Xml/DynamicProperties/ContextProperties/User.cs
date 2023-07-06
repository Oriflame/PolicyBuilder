using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class User : ContextProperty, IUser
    {
        public User(string path) : base(path)
        {
            Identities = new UserIdentities($"{Get()}.{nameof(Identities)}");
            Groups = new Groups($"{Get()}.{nameof(Groups)}");
        }

        public string Email => $"{Get()}.{nameof(Email)}";

        public string FirstName => $"{Get()}.{nameof(FirstName)}";

        public IGroups Groups { get; }

        public string Id => $"{Get()}.{nameof(Id)}";

        /// <summary>
        /// Type: <see cref="IEnumerable{IUserIdentity}"/>
        /// </summary>
        public IUserIdentities Identities { get; }

        public string LastName => $"{Get()}.{nameof(LastName)}";

        public string Note => $"{Get()}.{nameof(Note)}";

        /// <summary>
        /// Type <see cref="DateTime"/>
        /// </summary>
        public string RegistrationDate => $"{Get()}.{nameof(RegistrationDate)}";
    }
}