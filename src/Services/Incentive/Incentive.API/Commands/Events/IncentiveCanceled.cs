namespace Incentives.Services.Incentive.API.Commands.Events
{
    using System;
    using MediatR;

    public class IncentiveCanceled : EventBase, INotification
    {
        private IncentiveCanceled() { }

        public IncentiveCanceled(Guid id)
        {
            this.Id = id;
            this.CanceledAt = DateTimeOffset.Now;
        }

        public DateTimeOffset CanceledAt { get; private set; }
    }
}