namespace Incentives.Services.Membership.API.Queries.Denormalizers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Membership.API.Commands.Events;
    using Incentives.Services.Membership.API.Queries.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class MemberDenormalizer :
        INotificationHandler<MemberCreated>,
        INotificationHandler<MemberUpdated>
    {
        private readonly DefaultDbContext db;

        public MemberDenormalizer(DefaultDbContext db)
        {
            this.db = db;
        }

        async Task INotificationHandler<MemberCreated>.Handle(MemberCreated e, CancellationToken c)
        {
            var memberType =
                await db.MemberTypes
                    .SingleAsync(t => t.InternalId == e.MemberTypeId, c);

            var model = 
                await db.Members
                    .AddAsync(
                        new MemberData
                        {
                            CompleteName = e.CompleteName,
                            SortableName = e.SortableName,
                            MemberNumber = e.MemberNumber,
                            MemberType = new MemberData.MemberTypeData
                            {
                                MemberTypeId = memberType.InternalId,
                                CommonName = memberType.CommonName,
                            },
                            InternalId = e.Id,
                        });

            await db.SaveChangesAsync(c);
        }

        async Task INotificationHandler<MemberUpdated>.Handle(MemberUpdated e, CancellationToken c)
        {
            var memberType =
                await db.MemberTypes
                    .SingleAsync(t => t.InternalId == e.MemberTypeId, c);

            var result =
                await db.Members
                    .SingleAsync(u => u.InternalId == e.Id);

            result.CompleteName = e.CompleteName;
            result.SortableName = e.SortableName;
            result.MemberNumber = e.MemberNumber;
            result.MemberType.MemberTypeId = memberType.InternalId;
            result.MemberType.CommonName = memberType.CommonName;
            result.UpdateAt = DateTimeOffset.Now;

            await db.SaveChangesAsync();
        }
    }
}