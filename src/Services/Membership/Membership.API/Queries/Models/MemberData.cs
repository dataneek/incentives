namespace Incentives.Services.Membership.API.Queries.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MemberData : Entity, IEntityTypeConfiguration<MemberData>
    {
        public MemberTypeData MemberType { get; set; }

        public string CompleteName { get; set; }
        public string SortableName { get; set; }
        public string MemberNumber { get; set; }
        public bool IsActive { get; set; }

        public long MemberId { get; private set; }


        void IEntityTypeConfiguration<MemberData>.Configure(EntityTypeBuilder<MemberData> builder)
        {
            builder.HasKey(t => t.MemberId);
            builder.OwnsOne(t => t.MemberType);
        }


        public class MemberTypeData
        {
            public Guid MemberTypeId { get; set; }
            public string CommonName { get; set; }
        }
    }
}