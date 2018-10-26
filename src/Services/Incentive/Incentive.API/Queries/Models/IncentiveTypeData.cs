namespace Incentives.Services.Incentive.API.Queries.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IncentiveTypeData : Entity, IEntityTypeConfiguration<IncentiveTypeData>
    {
        public string CommonName { get; set; }
        public CostCodeData CostCode { get; set; }
        public bool IsActive { get; set; }
        public long IncentiveTypeId { get; set; }


        public class CostCodeData
        {
            public Guid CostCodeId { get; set; }
            public string CommonName { get; set; }
        }


        void IEntityTypeConfiguration<IncentiveTypeData>.Configure(EntityTypeBuilder<IncentiveTypeData> builder)
        {
            builder.OwnsOne(t => t.CostCode);
        }
    }
}