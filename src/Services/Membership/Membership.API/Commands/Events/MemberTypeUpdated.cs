namespace Incentives.Services.Membership.API.Commands.Events
{
    using System;
    using MediatR;

    public class MemberTypeUpdated : EventBase, INotification
    {
        private MemberTypeUpdated() { }

        public MemberTypeUpdated(Guid id, string commonName, bool isActive)
        {
            this.Id = id;
            this.CommonName = commonName;
            this.IsActive = isActive;
        }

        public string CommonName { get; private set; }
        public bool IsActive { get; private set; }
    }
}