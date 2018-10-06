namespace Incentives.Services.Accounting.API.Queries.Denormalizers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Accounting.API.Commands.Events;
    using Incentives.Services.Accounting.API.Queries.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class LedgerAccountDenormalizer :
        INotificationHandler<LedgerAccountCreated>,
        INotificationHandler<LedgerAccountUpdated>
    {
        private readonly DefaultDbContext db;

        public LedgerAccountDenormalizer(DefaultDbContext db)
        {
            this.db = db;
        }

        async Task INotificationHandler<LedgerAccountCreated>.Handle(LedgerAccountCreated e, CancellationToken t)
        {
            var model =
                await db.LedgerAccounts.AddAsync(
                    new LedgerAccountData
                    {
                        CommonName = e.CommonName,
                        AccountNumber = e.AccountNumber,
                        LedgerAccountExternalId = e.Id,
                    });

            await db.SaveChangesAsync(t);
        }

        async Task INotificationHandler<LedgerAccountUpdated>.Handle(LedgerAccountUpdated e, CancellationToken t)
        {
            var result =
                await db.LedgerAccounts
                    .SingleAsync(u => u.LedgerAccountExternalId == e.Id);

            result.CommonName = e.CommonName;
            result.AccountNumber = e.AccountNumber;
            result.IsActive = e.IsActive;

            await db.SaveChangesAsync();
        }
    }
}