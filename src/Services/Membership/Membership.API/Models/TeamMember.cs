namespace Incentives.Services.Membership.API.Models
{
    using System;

    public class TeamMember : Entity
    {
        private TeamMember() { }

        public TeamMember(Team team, Member member)
        {
            Team = team ?? throw new ArgumentNullException(nameof(team));
            Member = member ?? throw new ArgumentNullException(nameof(member));
        }


        public long TeamMemberId { get; private set; }
        public Guid TeamMemberExternalId { get; private set; } = Guid.NewGuid();

        public Team Team { get; private set; }
        public long TeamId { get; private set; }

        public Member Member { get; private set; }
        public long MemberId { get; private set; }

        public DateTimeOffset AssignedAt { get; private set; } = DateTimeOffset.Now;
        public bool IsDeleted { get; private set; } = false;
    }
}