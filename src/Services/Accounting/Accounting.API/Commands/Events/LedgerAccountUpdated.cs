namespace Incentives.Services.Accounting.API.Commands.Events
{
    using System;

    public class LedgerAccountUpdated : EventBase
    {
        private LedgerAccountUpdated() { }

        public LedgerAccountUpdated(Guid id, string commonName, string accountNumber, bool isActive)
        {
            this.Id = id;
            this.CommonName = commonName;
            this.AccountNumber = accountNumber;
            this.IsActive = isActive;
        }

        public string CommonName { get; private set; }
        public string AccountNumber { get; private set; }
        public bool IsActive { get; private set; }
    }
}