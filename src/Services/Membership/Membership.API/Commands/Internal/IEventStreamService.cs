namespace Incentives.Services.Membership.API.Commands
{
    using System;

    public interface IEventStreamService
    {
        IEventStream GetOrCreateStream(Guid aggregateId);
    }
}