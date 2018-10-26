namespace Incentives.Services.Incentive.API.Commands.Events
{
    using System;
    using MediatR;

    public class IncentivePaid : EventBase, INotification
    {
        private IncentivePaid() { }

        public IncentivePaid(Guid id)
        {
            this.Id = id;
            this.PaidAt = DateTimeOffset.Now;
        }

        public DateTimeOffset PaidAt { get; private set; }
    }
}