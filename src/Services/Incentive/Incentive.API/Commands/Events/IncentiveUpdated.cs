namespace Incentives.Services.Incentive.API.Commands.Events
{
    using System;
    using MediatR;

    public class IncentiveUpdated : EventBase, INotification
    {
        private IncentiveUpdated() { }

        public IncentiveUpdated(Guid id, decimal incentiveAmount)
        {
            this.Id = id;
            this.IncentiveAmount = incentiveAmount;
        }

        public decimal IncentiveAmount { get; private set; }
    }
}