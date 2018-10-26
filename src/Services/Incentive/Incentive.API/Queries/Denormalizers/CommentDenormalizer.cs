namespace Incentives.Services.Incentive.API.Queries.Denormalizers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Incentives.Services.Incentive.API.Commands.Events;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CommentDenormalizer : 
        INotificationHandler<CommentPosted>
    {
        private readonly DefaultDbContext db;

        public CommentDenormalizer(DefaultDbContext db)
        {
            this.db = db;
        }

        async Task INotificationHandler<CommentPosted>.Handle(CommentPosted e, CancellationToken cancellationToken)
        {
            var incentive =
                await this.db.Incentives
                    .SingleAsync(t => t.InternalId == e.IncentiveId);

            var comment =
                await this.db.Comments
                    .AddAsync(
                        new CommentData
                        {
                            InternalId = e.Id,
                            Incentive = new CommentData.IncentiveData
                            {
                                IncentiveId = e.IncentiveId,
                                IncentiveType = new CommentData.IncentiveData.IncentiveTypeData
                                {
                                    IncentiveTypeId = incentive.IncentiveType.IncentiveTypeId,
                                    CommonName = incentive.IncentiveType.CommonName,
                                },
                                Member = new CommentData.IncentiveData.MemberData
                                {
                                   
                                }
                            }
                        });

            await db.SaveChangesAsync(); 
        }
    }
}