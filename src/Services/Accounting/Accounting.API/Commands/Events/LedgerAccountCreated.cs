namespace Incentives.Services.Accounting.API.Commands.Events
{
    using System;

    public class LedgerAccountCreated : EventBase
    {
        private LedgerAccountCreated() { }

        public LedgerAccountCreated(Guid id, string commonName, string accountNumber)
        {
            this.Id = id;
            this.CommonName = commonName;
            this.AccountNumber = accountNumber;
        }

        public string CommonName { get; private set; }
        public string AccountNumber { get; private set; }
    }
}