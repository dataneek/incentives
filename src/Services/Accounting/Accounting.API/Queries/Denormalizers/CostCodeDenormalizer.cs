namespace Incentives.Services.Accounting.API.Queries.Denormalizers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Accounting.API.Commands.Events;
    using Incentives.Services.Accounting.API.Queries.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CostCodeDenormalizer :
        INotificationHandler<CostCodeCreated>,
        INotificationHandler<CostCodeUpdated>
    {
        private readonly DefaultDbContext db;

        public CostCodeDenormalizer(DefaultDbContext db)
        {
            this.db = db;
        }

        async Task INotificationHandler<CostCodeCreated>.Handle(CostCodeCreated e, CancellationToken t)
        {
            var model = 
                await db.CostCodes.AddAsync(
                    new CostCodeData
                    {
                        CommonName = e.CommonName,
                        UniqueIdentifier = e.UniqueIdentifier,
                        CostCodeExternalId = e.Id,
                    });

            await db.SaveChangesAsync(t);
        }

        async Task INotificationHandler<CostCodeUpdated>.Handle(CostCodeUpdated e, CancellationToken t)
        {
            var result =
                await db.CostCodes
                    .SingleAsync(u => u.CostCodeExternalId == e.Id);

            result.CommonName = e.CommonName;
            result.UniqueIdentifier = e.UniqueIdentifier;

            await db.SaveChangesAsync();
        }
    }
}