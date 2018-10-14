namespace Incentives.Services.Membership.API.Commands.Events
{
    using System;
    using MediatR;

    public class MemberUpdated : EventBase, INotification
    {
        private MemberUpdated() { }

        public MemberUpdated(Guid id, Guid memberTypeId, string completeName, string sortableName, string memberNumber, bool isActive)
        {
            this.Id = id;

            this.CompleteName = CompleteName;
            this.SortableName = sortableName;
            this.MemberNumber = memberNumber;
            this.MemberTypeId = memberTypeId;
            this.IsActive = isActive;
        }

        public string CompleteName { get; private set; }
        public string SortableName { get; private set; }
        public string MemberNumber { get; private set; }
        public Guid MemberTypeId { get; private set; }
        public bool IsActive { get; private set; }
    }
}