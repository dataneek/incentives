namespace Incentives.Services.Membership.API.Commands.Events
{
    using System;
    using MediatR;

    public class TeamCreated : EventBase, INotification
    {
        private TeamCreated() { }

        public TeamCreated(Guid id, string commonName, string uniqueIdentifier)
        {
            this.Id = id;
            this.CommonName = commonName;
            this.UniqueIdentifier = uniqueIdentifier;
        }

        public string CommonName { get; private set; }
        public string UniqueIdentifier { get; private set; }
    }
}