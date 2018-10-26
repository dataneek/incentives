namespace Incentives.Services.Incentive.API.Queries.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IncentiveData : Entity, IEntityTypeConfiguration<IncentiveData>
    {
        public MemberData Member { get; set; }
        public IncentiveTypeData IncentiveType { get; set; }
        public CostCodeData CostCode { get; set; }

        public decimal IncentiveAmount { get; set; }

        public bool IsSubmitted { get; set; } = false;
        public bool IsReviewed { get; set; } = false;
        public bool IsCanceled { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public bool IsPaid { get; set; } = false;

        public DateTimeOffset? SubmitAt { get; set; } = null;
        public DateTimeOffset? ReviewAt { get; set; } = null;
        public DateTimeOffset? CancelAt { get; set; } = null;
        public DateTimeOffset? CompleteAt { get; set; } = null;
        public DateTimeOffset? PaidAt { get; set; } = null;

        internal void Pay()
        {
            throw new NotImplementedException();
        }

        public long IncentiveId { get; private set; }


        public class MemberData
        {
            public Guid MemberId { get; set; }
            public string CompleteName { get; set; }
        }

        public class IncentiveTypeData
        {
            public Guid IncentiveTypeId { get; set; }
            public string CommonName { get; set; }
        }

        public class CostCodeData
        {
            public Guid CostCodeId { get; set; }
            public string CommonName { get; set; }
        }


        void IEntityTypeConfiguration<IncentiveData>.Configure(EntityTypeBuilder<IncentiveData> builder)
        {
            builder.OwnsOne(t => t.CostCode);
            builder.OwnsOne(t => t.IncentiveType);
            builder.OwnsOne(t => t.Member);
        }
    }
}