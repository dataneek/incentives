namespace Incentives.Services.Incentive.API.Commands.Models
{
    using System;
    using CQRSlite.Domain;
    using Events;

    public class IncentiveType : AggregateRoot
    {
        private IncentiveType() { }

        public IncentiveType(Guid id, string commonName, Guid costCodeId)
        {
            this.Id = id;
            ApplyChange(new IncentiveTypeCreated(id, commonName, costCodeId));
        }


        public string CommonName { get; private set; }
        public Guid CostCodeId { get; private set; }
        public bool IsActive { get; private set; } = true;


        public void Update(string commonName, string description, Guid costCodeId, bool isActive)
        {
            ApplyChange(new IncentiveTypeUpdated(this.Id, commonName, costCodeId, isActive));
        }

        private void Apply(IncentiveTypeCreated e)
        {
            this.CommonName = e.CommonName;
            this.CostCodeId = e.CostCodeId;
        }

        private void Apply(IncentiveTypeUpdated e)
        {
            this.CommonName = e.CommonName;
            this.CostCodeId = e.CostCodeId;
            this.IsActive = e.IsActive;
        }
    }
}