namespace Incentives.Services.Incentive.API.Queries.Denormalizers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Incentive.API.Commands.Events;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class IncentiveTypeDenormalizer :
        INotificationHandler<IncentiveTypeCreated>, 
        INotificationHandler<IncentiveTypeUpdated>
    {
        private readonly DefaultDbContext db;

        public IncentiveTypeDenormalizer(DefaultDbContext db)
        {
            this.db = db;
        }

        async Task INotificationHandler<IncentiveTypeCreated>.Handle(IncentiveTypeCreated e, CancellationToken cancellationToken)
        {
            var incentiveType =
                await db.IncentiveTypes.AddAsync(
                    new IncentiveTypeData
                    {
                        InternalId = e.Id,
                        CommonName = e.CommonName,
                        IsActive = true,
                    });

            await db.SaveChangesAsync(cancellationToken);
        }

        async Task INotificationHandler<IncentiveTypeUpdated>.Handle(IncentiveTypeUpdated e, CancellationToken cancellationToken)
        {
            var incentiveType =
                await db.IncentiveTypes
                    .SingleAsync(t => t.InternalId == e.Id);

            incentiveType.CommonName = e.CommonName;
            incentiveType.IsActive = e.IsActive;

            await db.SaveChangesAsync();
        }
    }
}