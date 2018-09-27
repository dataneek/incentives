namespace Incentives.Services.Accounting.API.Models
{
    using System;

    public class LedgerAccount : Entity
    {
        private LedgerAccount() { }

        public LedgerAccount(string commonName, string accountNumber)
        {
            this.CommonName = commonName;
            this.AccountNumber = accountNumber;
        }

        public long LedgerAccountId { get; private set; }
        public Guid LedgerAccountExternalId { get; private set; } = Guid.NewGuid();

        public string CommonName { get; private set; }
        public string AccountNumber { get; private set; }


        public void Update(string commonName, string accountNumber)
        {
            this.CommonName = commonName;
            this.AccountNumber = accountNumber;

            OnUpdate();
        }
    }
}