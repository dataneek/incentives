namespace Incentives.Services.Accounting.API.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Accounting.API.Commands.Models;

    public interface IRepository
    {
        Task SaveAsync<T>(T aggregate, int? expectedVersionNumber = null, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot;

        Task<T> GetAsync<T>(Guid aggregateId, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot;
    }
}