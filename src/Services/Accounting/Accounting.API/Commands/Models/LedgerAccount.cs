namespace Incentives.Services.Accounting.API.Commands.Models
{
    using Incentives.Services.Accounting.API.Commands.Events;
    using System;

    public class LedgerAccount : AggregateRoot
    {
        private LedgerAccount() { }

        public LedgerAccount(Guid id, string commonName, string accountNumber)
        {
            this.Id = id;
            RaiseEvent(new LedgerAccountCreated(id, commonName, accountNumber));
        }


        public string CommonName { get; private set; }
        public string AccountNumber { get; private set; }
        public bool IsActive { get; private set; }


        public void Update(string commonName, string accountNumber, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(commonName))
                throw new ArgumentNullException(nameof(commonName));

            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentNullException(nameof(accountNumber));

            RaiseEvent(new LedgerAccountUpdated(this.Id, commonName, accountNumber, isActive));
        }

        private void Apply(LedgerAccountCreated e)
        {
            this.CommonName = e.CommonName;
            this.AccountNumber = e.AccountNumber;
        }

        private void Apply(LedgerAccountUpdated e)
        {
            this.CommonName = e.CommonName;
            this.AccountNumber = e.AccountNumber;
            this.IsActive = e.IsActive;
        }
    }
}