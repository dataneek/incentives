namespace Incentives.Services.Accounting.API.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Accounting.API.Commands.Models;

    public interface ISession
    {
        Task AddAsync<T>(T aggregate, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot;

        Task<T> GetAsync<T>(Guid id, int? expectedVersionNumber = null, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot;

        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}