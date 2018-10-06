namespace Incentives.Services.Accounting.API.Queries.Models
{
    using System;

    public class LedgerAccountData : Entity
    {
        public long LedgerAccountId { get; set; }
        public Guid LedgerAccountExternalId { get; set; }

        public string CommonName { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }
    }
}