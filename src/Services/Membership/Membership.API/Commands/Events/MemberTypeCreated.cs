namespace Incentives.Services.Membership.API.Commands.Events
{
    using System;
    using MediatR;

    public class MemberTypeCreated : EventBase, INotification
    {
        private MemberTypeCreated() { }

        public MemberTypeCreated(Guid id, string commonName)
        {
            this.Id = id;
            this.CommonName = commonName;
        }

        public string CommonName { get; private set; }
    }
}