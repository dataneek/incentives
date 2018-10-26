namespace Incentives.Services.Incentive.API.Commands.Events
{
    using System;
    using MediatR;

    public class IncentiveSubmitted : EventBase, INotification
    {
        private IncentiveSubmitted() { }

        public IncentiveSubmitted(Guid id)
        {
            this.Id = id;
            this.SubmittedAt = DateTimeOffset.Now;
        }

        public DateTimeOffset SubmittedAt { get; private set; }
    }
}