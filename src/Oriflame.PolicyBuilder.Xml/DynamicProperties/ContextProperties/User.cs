using System;
using System.Collections.Generic;
using Oriflame.PolicyBuilder.Policies.DynamicProperties.ContextProperties;

namespace Oriflame.PolicyBuilder.Xml.DynamicProperties.ContextProperties
{
    public class User : ContextProperty, IUser
    {
        public User(string path) : base(path)
        {
            Identities = new UserIdentities(GetPropertyPath(nameof(Identities)));
            Groups = new Groups(GetPropertyPath(nameof(Groups)));
        }

        public string Email => GetPropertyPath(nameof(Email));

        public string FirstName => GetPropertyPath(nameof(FirstName));

        public IGroups Groups { get; }

        public string Id => GetPropertyPath(nameof(Id));

        /// <summary>
        /// Type: <see cref="IEnumerable{IUserIdentity}"/>
        /// </summary>
        public IUserIdentities Identities { get; }

        public string LastName => GetPropertyPath(nameof(LastName));

        public string Note => GetPropertyPath(nameof(Note));

        /// <summary>
        /// Type <see cref="DateTime"/>
        /// </summary>
        public string RegistrationDate => GetPropertyPath(nameof(RegistrationDate));
    }
}