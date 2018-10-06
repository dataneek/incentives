namespace Incentives.Services.Accounting.API.Commands.Events
{
    using System;

    public class CostCodeUpdated : EventBase
    {
        private CostCodeUpdated() { }

        public CostCodeUpdated(Guid id, string commonName, string uniqueIdentifier, bool isActive)
        {
            this.Id = id;
            this.CommonName = commonName;
            this.UniqueIdentifier = uniqueIdentifier;
            this.IsActive = isActive;
        }

        public string CommonName { get; private set; }
        public string UniqueIdentifier { get; private set; }
        public bool IsActive { get; private set; }
    }
}