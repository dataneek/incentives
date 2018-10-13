namespace Incentives.Services.Membership.API.Commands.Events
{
    using System;
    using MediatR;

    public class TeamAssignmentCreated : EventBase, INotification
    {
        private TeamAssignmentCreated() { }

        public TeamAssignmentCreated(Guid id, Guid teamId, Guid memberId)
        {
            this.Id = id;
            this.TeamId = teamId;
            this.MemberId = memberId;
        }

        public Guid TeamId { get; private set; }
        public Guid MemberId { get; private set; }
    }
}