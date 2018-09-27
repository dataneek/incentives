namespace Incentives.Services.Membership.API.Models
{
    using System;

    public class Team : Entity
    {
        private Team() { }

        public Team(string commonName, string uniqueIdentifier)
        {
            this.CommonName = commonName ?? throw new ArgumentNullException(nameof(commonName));
        }


        public string CommonName { get; private set; }
        public string UniqueIdentifier { get; private set; }

        public long TeamId { get; private set; }
        public Guid TeamExternalId { get; private set; }

        public bool IsDeleted { get; private set; }


        public void Update(string commonName, string uniqueIdentifier)
        {
            this.CommonName = commonName ?? throw new ArgumentNullException(nameof(commonName));
            OnUpdate();
        }

        public void MarkAsDeleted()
        {
            this.IsDeleted = true;
            OnUpdate();
        }
    }
}