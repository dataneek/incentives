namespace Incentives.Services.Accounting.API.Commands
{
    using System;

    public abstract class EventBase : IEvent
    {
        public Guid Id { get; set; }
        public int VersionNumber { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}