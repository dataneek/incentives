namespace Incentives.Services.Accounting.API.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IEventStore
    {
        Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default(CancellationToken));
    }
}