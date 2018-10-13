namespace Incentives.Services.Membership.API.Queries.Denormalizers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Membership.API.Commands.Events;
    using Incentives.Services.Membership.API.Queries.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class MemberTypeDenormalizer :
        INotificationHandler<MemberTypeCreated>,
        INotificationHandler<MemberTypeUpdated>
    {
        private readonly DefaultDbContext db;

        public MemberTypeDenormalizer(DefaultDbContext db)
        {
            this.db = db;
        }

        async Task INotificationHandler<MemberTypeCreated>.Handle(MemberTypeCreated e, CancellationToken c)
        {
            var memberType = 
                await db.MemberTypes
                    .AddAsync(
                        new MemberTypeData
                        {
                            CommonName = e.CommonName,
                            IsActive = true,
                            MemberCount = 0,
                            InternalId = e.Id,
                        });

            await db.SaveChangesAsync(c);
        }

        async Task INotificationHandler<MemberTypeUpdated>.Handle(MemberTypeUpdated e, CancellationToken c)
        {
            var memberType =
                await db.MemberTypes
                    .SingleAsync(t => t.InternalId == e.Id, c);

            memberType.CommonName = e.CommonName;
            memberType.IsActive  = e.IsActive;

            memberType.UpdateAt = DateTimeOffset.Now;

            await db.SaveChangesAsync();
        }
    }
}