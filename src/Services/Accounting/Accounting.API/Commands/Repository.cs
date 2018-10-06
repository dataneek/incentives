namespace Incentives.Services.Accounting.API.Commands
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Accounting.API.Commands.Models;
    using Incentives.Services.Accounting.API.Models;

    public class Repository : IRepository
    {
        private readonly IEventStore eventStore;

        public Repository(IEventStore eventStore)
        {
            this.eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public async Task SaveAsync<T>(T aggregate, int? expectedVersion = null, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            if (expectedVersion != null && (await eventStore.Get(aggregate.Id, expectedVersion.Value, cancellationToken).ConfigureAwait(false)).Any())
            {
                throw new ConcurrencyException(aggregate.Id);
            }

            var changes = aggregate.FlushUncommittedChanges();
            await eventStore.Save(changes, cancellationToken).ConfigureAwait(false);
        }

        public Task<T> GetAsync<T>(Guid aggregateId, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            return LoadAggregate<T>(aggregateId, cancellationToken);
        }

        private async Task<T> LoadAggregate<T>(Guid id, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            var events = 
                await eventStore.Get(id, -1, cancellationToken).ConfigureAwait(false);

            if (!events.Any())
            {
                throw new AggregateNotFoundException(typeof(T), id);
            }

            var aggregate = AggregateFactory<T>.CreateAggregate();
            aggregate.LoadFromHistory(events);
            return aggregate;
        }
    }
}