namespace Incentives.Services.Accounting.API.Commands.Events
{
    using System;

    public class CostCodeCreated : EventBase
    {
        private CostCodeCreated() { }

        public CostCodeCreated(Guid id, string commonName, string uniqueIdentifier)
        {
            this.Id = id;
            this.CommonName = commonName;
            this.UniqueIdentifier = uniqueIdentifier;
        }

        public string CommonName { get; private set; }
        public string UniqueIdentifier { get; private set; }
    }
}