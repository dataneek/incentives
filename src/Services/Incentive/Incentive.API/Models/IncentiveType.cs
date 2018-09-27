namespace Incentives.Services.Incentive.API.Models
{
    using System;

    public class IncentiveType : Entity
    {
        private IncentiveType() { }

        public IncentiveType(string commonName, CostCode costCode)
        {
            this.CommonName = commonName ?? throw new ArgumentNullException(nameof(commonName));
            this.CostCode = costCode ?? throw new ArgumentNullException(nameof(costCode));
        }


        public string CommonName { get; private set; }

        public CostCode CostCode { get; private set; }
        public long CostCodeId { get; private set; }

        public long IncentiveTypeId { get; private set; }
        public Guid IncentiveTypeExternalId { get; private set; } = Guid.NewGuid();
        public bool IsActive { get; private set; } = true;


        public void Update(string commonName, string description, CostCode costCode, bool isActive)
        {
            this.CommonName = commonName;
            this.CostCode = costCode;
            this.IsActive = isActive;

            OnUpdate();
        }
    }
}