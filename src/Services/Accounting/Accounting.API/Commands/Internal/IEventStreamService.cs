namespace Incentives.Services.Accounting.API.Commands
{
    using System;

    public interface IEventStreamService
    {
        IEventStream GetOrCreateStream(Guid aggregateId);
    }
}