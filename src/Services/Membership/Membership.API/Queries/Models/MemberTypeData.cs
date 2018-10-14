namespace Incentives.Services.Membership.API.Queries.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MemberTypeData : Entity, IEntityTypeConfiguration<MemberTypeData>
    {
        public string CommonName { get; set; }
        public bool IsActive { get; set; }
        public long MemberCount { get; set; }

        public long MemberTypeId { get; set; }


        void IEntityTypeConfiguration<MemberTypeData>.Configure(EntityTypeBuilder<MemberTypeData> builder)
        {
            builder.HasKey(t => t.MemberTypeId);
        }
    }
}