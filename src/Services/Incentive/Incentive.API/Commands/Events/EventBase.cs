namespace Incentives.Services.Incentive.API.Commands
{
    using System;
    using CQRSlite.Events;

    public abstract class EventBase : IEvent
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}