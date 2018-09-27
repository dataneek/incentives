namespace Incentives.Services.Accounting.API.Models
{
    using System;

    public class CostCode : Entity
    {
        private CostCode() { }

        public CostCode(string commonName, string uniqueIdentifier)
        {
            this.CommonName = commonName;
            this.UniqueIdentifier = uniqueIdentifier;
        }

        public long CostCodeId { get; private set; }
        public Guid CostCodeExternalId { get; private set; } = Guid.NewGuid();

        public string CommonName { get; private set; }
        public string UniqueIdentifier { get; private set; }
        public bool IsActive { get; private set; } = true;


        public void Update(string commonName, string uniqueIdentifier)
        {
            this.CommonName = commonName;
            this.UniqueIdentifier = uniqueIdentifier;

            OnUpdate();
        }

        public void MarkAsNotActive()
        {
            this.IsActive = false;
            OnUpdate();
        }
    }
}