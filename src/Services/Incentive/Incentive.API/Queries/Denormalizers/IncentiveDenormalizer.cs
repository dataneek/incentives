namespace Incentives.Services.Incentive.API.Queries.Denormalizers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Incentive.API.Commands.Events;
    using Incentives.Services.Incentive.API.Queries.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class IncentiveDenormalizer :
        INotificationHandler<IncentiveCreated>,
        INotificationHandler<IncentiveUpdated>,
        INotificationHandler<IncentiveCanceled>,
        INotificationHandler<IncentivePaid>,
        INotificationHandler<IncentiveSubmitted>
    {
        private readonly DefaultDbContext db;

        public IncentiveDenormalizer(DefaultDbContext db)
        {
            this.db = db;
        }

        async Task INotificationHandler<IncentivePaid>.Handle(IncentivePaid e, CancellationToken cancellationToken)
        {
            var incentive =
                await db.Incentives
                    .SingleAsync(t => t.InternalId == e.Id);

            incentive.IsPaid = true;
            incentive.PaidAt = e.TimeStamp;

            await db.SaveChangesAsync();
        }

        async Task INotificationHandler<IncentiveCreated>.Handle(IncentiveCreated e, CancellationToken cancellationToken)
        {
            var incentive =
                await db.Incentives.AddAsync(
                    new IncentiveData
                    {
                        Member = new IncentiveData.MemberData
                        {

                        },
                        IncentiveType = new IncentiveData.IncentiveTypeData
                        {

                        },
                        IncentiveAmount = e.IncentiveAmount,
                    });
        }

        async Task INotificationHandler<IncentiveUpdated>.Handle(IncentiveUpdated e, CancellationToken cancellationToken)
        {
            var incentive =
                await db.Incentives
                    .SingleAsync(t => t.InternalId == e.Id);

            incentive.IncentiveAmount = e.IncentiveAmount;
            incentive.UpdateAt = DateTimeOffset.Now;

            await db.SaveChangesAsync();
        }

        async Task INotificationHandler<IncentiveCanceled>.Handle(IncentiveCanceled e, CancellationToken cancellationToken)
        {
            var incentive =
                await db.Incentives
                    .SingleAsync(t => t.InternalId == e.Id);

            incentive.IsCanceled = true;
            incentive.CancelAt = e.TimeStamp;

            await db.SaveChangesAsync();
        }

        async Task INotificationHandler<IncentiveSubmitted>.Handle(IncentiveSubmitted e, CancellationToken cancellationToken)
        {
            var incentive =
                await db.Incentives
                    .SingleAsync(t => t.InternalId == e.Id);

            incentive.IsSubmitted = true;
            incentive.SubmitAt = e.TimeStamp;

            await db.SaveChangesAsync();
        }
    }
}