namespace Incentives.Services.Accounting.API.Commands
{
    using System;
    using System.Collections.Generic;

    public class InMemoryEventStreamService : IEventStreamService
    {
        private readonly IDictionary<Guid, IEventStream> streams = new Dictionary<Guid, IEventStream>();

        IEventStream IEventStreamService.GetOrCreateStream(Guid aggregateId)
        {
            streams.TryGetValue(aggregateId, out var result);

            if (result == null)
            {
                result = new InMemoryEventStream(aggregateId);
                streams.Add(aggregateId, result);
            }

            return result;
        }
    }
}