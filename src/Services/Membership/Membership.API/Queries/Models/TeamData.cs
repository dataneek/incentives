namespace Incentives.Services.Membership.API.Queries.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeamData : Entity, IEntityTypeConfiguration<TeamData>
    {
        public string CommonName { get; set; }
        public string UniqueIdentifier { get; set; }
        public bool IsActive { get; set; }
        public int TeamMemberCount { get; set; }

        public long TeamId { get; set; }


        void IEntityTypeConfiguration<TeamData>.Configure(EntityTypeBuilder<TeamData> builder)
        {
            builder.HasKey(t => t.TeamId);
        }
    }
}