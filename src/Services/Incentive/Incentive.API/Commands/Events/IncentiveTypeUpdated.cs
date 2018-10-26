namespace Incentives.Services.Incentive.API.Commands.Events
{
    using System;
    using MediatR;

    public class IncentiveTypeUpdated : EventBase, INotification
    {
        private IncentiveTypeUpdated() { }

        public IncentiveTypeUpdated(Guid id, string commonName, Guid costCodeId, bool isActive)
        {
            this.Id = id;
            this.CommonName = commonName;
            this.CostCodeId = costCodeId;
            this.IsActive = isActive;
        }

        public string CommonName { get; private set; }
        public Guid CostCodeId { get; private set; }
        public bool IsActive { get; private set; }
    }
}