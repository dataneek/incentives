namespace Incentives.Services.Membership.API.Commands.Events
{
    using System;
    using MediatR;

    public class MemberCreated : EventBase, INotification
    {
        private MemberCreated() { }

        public MemberCreated(Guid id, Guid memberTypeId, string completeName, string sortableName, string memberNumber)
        {
            this.Id = id;

            this.CompleteName = CompleteName;
            this.SortableName = sortableName;
            this.MemberNumber = memberNumber;
            this.MemberTypeId = memberTypeId;
        }

        public string CompleteName { get; private set; }
        public string SortableName { get; private set; }
        public string MemberNumber { get; private set; }
        public Guid MemberTypeId { get; private set; }
    }
}