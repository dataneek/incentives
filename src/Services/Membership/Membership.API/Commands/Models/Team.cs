namespace Incentives.Services.Membership.API.Models
{
    using System;
    using CQRSlite.Domain;
    using Incentives.Services.Membership.API.Commands.Events;

    public class Team : AggregateRoot
    {
        private Team() { }

        public Team(Guid id, string commonName, string uniqueIdentifier)
        {
            this.Id = id;
            ApplyChange(new TeamCreated(this.Id, commonName, uniqueIdentifier));
        }


        public string CommonName { get; private set; }
        public string UniqueIdentifier { get; private set; }
        public bool IsActive { get; private set; } = true;


        public void Update(string commonName, string uniqueIdentifier, bool isActive)
        {
            ApplyChange(new TeamUpdated(this.Id, commonName, uniqueIdentifier, isActive));
        }

        private void Apply(TeamCreated e)
        {
            this.CommonName = e.CommonName ?? throw new ArgumentNullException(nameof(e.CommonName));
        }

        private void Apply(TeamUpdated e)
        {
            this.CommonName = e.CommonName ?? throw new ArgumentNullException(nameof(e.CommonName));
            this.IsActive = e.IsActive;
        }
    }
}