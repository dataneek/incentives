namespace Incentives.Services.Incentive.API.Commands.Events
{
    using System;
    using MediatR;

    public class IncentiveTypeCreated : EventBase, INotification
    {
        private IncentiveTypeCreated() { }

        public IncentiveTypeCreated(Guid id, string commonName, Guid costCodeId)
        {
            this.Id = id;
            this.CommonName = commonName;
            this.CostCodeId = costCodeId;
        }

        public string CommonName { get; private set; }
        public Guid CostCodeId { get; private set; }
    }
}