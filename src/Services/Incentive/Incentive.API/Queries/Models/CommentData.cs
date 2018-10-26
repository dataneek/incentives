namespace Incentives.Services.Incentive.API.Queries.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentData : Entity, IEntityTypeConfiguration<CommentData>
    {
        public IncentiveData Incentive { get; set; }
        public string CommentBody { get; set; }

        public long IncentiveCommentId { get; private set; }


        public class IncentiveData
        {
            public Guid IncentiveId { get; set; }
            public IncentiveTypeData IncentiveType { get; set; }
            public MemberData Member { get; set; }

            public class IncentiveTypeData
            {
                public Guid IncentiveTypeId { get; set; }
                public string CommonName { get; set; }
            }

            public class MemberData
            {
                public Guid MemberId { get; set; }
                public string CommonName { get; set; }
            }
        }


        void IEntityTypeConfiguration<CommentData>.Configure(EntityTypeBuilder<CommentData> builder)
        {
            builder.OwnsOne(t => t.Incentive);
            builder.OwnsOne(t => t.Incentive).OwnsOne(t => t.IncentiveType);
            builder.OwnsOne(t => t.Incentive).OwnsOne(t => t.Member);
        }
    }
}