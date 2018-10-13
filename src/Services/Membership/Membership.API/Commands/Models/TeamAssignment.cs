namespace Incentives.Services.Membership.API.Models
{
    using System;
    using CQRSlite.Domain;
    using Incentives.Services.Membership.API.Commands.Events;

    public class TeamAssignment : AggregateRoot
    {
        private TeamAssignment() { }

        public TeamAssignment(Guid id, Guid teamId, Guid memberId)
        {
            Id = id;
            ApplyChange(new TeamAssignmentCreated(id, teamId, memberId));
        }


        public Guid TeamId { get; private set; }
        public Guid MemberId { get; private set; }
        public bool IsCanceled { get; private set; } = false;


        public void CancelAssignment()
        {
            if (IsCanceled)
                throw new AggregateException("Assignment is already canceled");

            ApplyChange(new TeamAssignmentCreated(Id, TeamId, MemberId));
        }


        private void Apply(TeamAssignmentCreated e)
        {
            TeamId = e.TeamId;
            MemberId = e.MemberId;
        }

        private void Apply(TeamAssignmentCanceled e)
        {
            IsCanceled = true;
        }
    }
}