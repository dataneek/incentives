namespace Incentives.Services.Accounting.API.Commands
{
    using System;
    using System.Collections.Generic;
    using CQRSlite.Events;

    public class InMemoryEventStream : List<IEvent>, IEventStream
    {
        private readonly Guid aggregateId;
        private readonly IList<IEvent> events = new List<IEvent>();

        public InMemoryEventStream(Guid aggregateId)
        {
            this.aggregateId = aggregateId;
        }
    }
}