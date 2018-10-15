namespace Incentives.Services.Accounting.API.Commands
{
    using System;
    using CQRSlite.Events;
    using MediatR;

    public abstract class EventBase : IEvent, INotification
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}