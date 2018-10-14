namespace Incentives.Services.Membership.API.Queries.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeamAssignmentData : Entity, IEntityTypeConfiguration<TeamAssignmentData>
    {
        public long TeamAssignmentId { get; private set; }

        public MemberData Member { get; set; }
        public TeamData Team { get; set; }
        public bool IsCanceled { get; set; }


        void IEntityTypeConfiguration<TeamAssignmentData>.Configure(EntityTypeBuilder<TeamAssignmentData> builder)
        {
            builder.HasKey(t => t.TeamAssignmentId);
            builder.OwnsOne(t => t.Member);
            builder.OwnsOne(t => t.Team);
        }


        public class MemberData
        {
            public Guid MemberId { get; set; }
            public string CompleteName { get; set; }
            public string SortableName { get; set; }
            public string MemberNumber { get; set; }
        }

        public class TeamData
        {
            public Guid TeamId { get; set; }
            public string CommonName { get; set; }
            public string UniqueIdentifier { get; set; }
        }
    }
}