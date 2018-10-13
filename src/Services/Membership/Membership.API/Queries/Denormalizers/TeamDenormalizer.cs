namespace Incentives.Services.Membership.API.Queries.Denormalizers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Membership.API.Commands.Events;
    using Incentives.Services.Membership.API.Queries.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class TeamDenormalizer :
        INotificationHandler<TeamCreated>,
        INotificationHandler<TeamUpdated>
    {
        private readonly DefaultDbContext db;

        public TeamDenormalizer(DefaultDbContext db)
        {
            this.db = db;
        }

        async Task INotificationHandler<TeamCreated>.Handle(TeamCreated e, CancellationToken t)
        {
            var model = 
                await db.Teams.AddAsync(
                    new TeamData
                    {
                        CommonName = e.CommonName,
                        UniqueIdentifier = e.UniqueIdentifier,
                        InternalId = e.Id,
                    });

            await db.SaveChangesAsync(t);
        }

        async Task INotificationHandler<TeamUpdated>.Handle(TeamUpdated e, CancellationToken t)
        {
            var result =
                await db.Teams
                    .SingleAsync(u => u.InternalId == e.Id);

            result.CommonName = e.CommonName;
            result.UniqueIdentifier = e.UniqueIdentifier;

            await db.SaveChangesAsync();
        }
    }
}