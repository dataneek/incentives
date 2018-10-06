namespace Incentives.Services.Accounting.API.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Accounting.API.Commands.Models;
    using Incentives.Services.Accounting.API.Models;

    public class Session : ISession
    {
        private readonly IRepository repository;
        private readonly IDictionary<Guid, AggregateDescriptor> trackedAggregates;

        public Session(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));

            trackedAggregates = new Dictionary<Guid, AggregateDescriptor>();
        }

        public Task AddAsync<T>(T aggregate, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            if (!IsTracked(aggregate.Id))
            {
                trackedAggregates.Add(aggregate.Id, new AggregateDescriptor { Aggregate = aggregate, Version = aggregate.VersionNumber });
            }
            else if (trackedAggregates[aggregate.Id].Aggregate != aggregate)
            {
                throw new ConcurrencyException(aggregate.Id);
            }
            return Task.FromResult(0);
        }

        public async Task<T> GetAsync<T>(Guid id, int? expectedVersionNumber = null, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            if (IsTracked(id))
            {
                var trackedAggregate = (T)trackedAggregates[id].Aggregate;
                if (expectedVersionNumber != null && trackedAggregate.VersionNumber != expectedVersionNumber)
                {
                    throw new ConcurrencyException(trackedAggregate.Id);
                }
                return trackedAggregate;
            }

            var aggregate = 
                await repository.GetAsync<T>(id, cancellationToken).ConfigureAwait(false);

            if (expectedVersionNumber != null && aggregate.VersionNumber != expectedVersionNumber)
            {
                throw new ConcurrencyException(id);
            }
            await AddAsync(aggregate, cancellationToken).ConfigureAwait(false);

            return aggregate;
        }

        private bool IsTracked(Guid id)
        {
            return trackedAggregates.ContainsKey(id);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var tasks = new Task[trackedAggregates.Count];
            var i = 0;
            foreach (var descriptor in trackedAggregates.Values)
            {
                tasks[i] = 
                    repository.SaveAsync(descriptor.Aggregate, descriptor.Version, cancellationToken);
                i++;
            }
            await Task.WhenAll(tasks).ConfigureAwait(false);

            trackedAggregates.Clear();
        }

        private class AggregateDescriptor
        {
            public AggregateRoot Aggregate { get; set; }
            public int Version { get; set; }
        }
    }
}