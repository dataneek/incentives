namespace Incentives.Services.Membership.API.Queries.Denormalizers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Membership.API.Commands.Events;
    using Incentives.Services.Membership.API.Queries.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class TeamAssignmentDenormalizer :
        INotificationHandler<TeamAssignmentCreated>,
        INotificationHandler<TeamAssignmentCanceled>
    {
        private readonly DefaultDbContext db;

        public TeamAssignmentDenormalizer(DefaultDbContext db)
        {
            this.db = db;
        }

        async Task INotificationHandler<TeamAssignmentCreated>.Handle(TeamAssignmentCreated e, CancellationToken t)
        {
            var team =
                await db.Teams
                    .SingleOrDefaultAsync(m => m.InternalId == e.TeamId);

            var member =
                await db.Members
                    .SingleOrDefaultAsync(m => m.InternalId == e.MemberId);

            var model = 
                await db.TeamAssignments.AddAsync(
                    new TeamAssignmentData
                    {
                        Member = new TeamAssignmentData.MemberData
                        {
                            CompleteName = member.CompleteName,
                            SortableName = member.SortableName,
                            MemberNumber = member.MemberNumber,
                            MemberId = member.InternalId,
                        },
                        Team = new TeamAssignmentData.TeamData
                        {
                            CommonName = team.CommonName,
                            UniqueIdentifier = team.UniqueIdentifier,
                            TeamId = team.InternalId,
                        },
                        IsCanceled = false,
                        InternalId = e.Id
                    });

            await db.SaveChangesAsync(t);
        }

        async Task INotificationHandler<TeamAssignmentCanceled>.Handle(TeamAssignmentCanceled e, CancellationToken t)
        {
            var result =
                await db.TeamAssignments
                    .SingleAsync(u => u.InternalId == e.Id);

            result.IsCanceled = true;
            result.UpdateAt = DateTimeOffset.Now;

            await db.SaveChangesAsync();
        }
    }
}