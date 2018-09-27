namespace Incentives.Services.Incentive.API.Models
{
    using System;

    public class CostCode
    {
        private CostCode() { }

        public CostCode(string commonName)
        {
            this.CommonName = commonName;
        }

        public long CostCodeId { get; private set; }
        public Guid CostCodeExternalId { get; private set; } = Guid.NewGuid();

        public string CommonName { get; private set; }
    }
}