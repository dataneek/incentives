namespace Incentives.Services.Membership.API.Commands.Events
{
    using System;
    using MediatR;

    public class TeamUpdated : EventBase, INotification
    {
        private TeamUpdated() { }

        public TeamUpdated(Guid id, string commonName, string uniqueIdentifier, bool isActive)
        {
            this.Id = id;
            this.CommonName = commonName;
            this.UniqueIdentifier = uniqueIdentifier;
            this.IsActive = isActive;
        }

        public string CommonName { get; private set; }
        public string UniqueIdentifier { get; private set; }
        public bool IsActive { get; private set; }
    }
}