namespace Incentives.Services.Accounting.API.Queries.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CostCodeData : Entity
    {
        public long CostCodeId { get; set; }
        public Guid CostCodeExternalId { get; set; }

        public string CommonName { get; set; }
        public string UniqueIdentifier { get; set; }
    }
}