namespace Incentives.Services.Membership.API.Queries.Features.Teams
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class About
    {
        public class Request : IRequest<TeamData>
        {
            public Guid? TeamId { get; set; }
        }


        public class RequestHandler : IRequestHandler<Request, TeamData>
        {
            private readonly IReadonlyDatabase db;

            public RequestHandler(IReadonlyDatabase db)
            {
                this.db = db;
            }

            async Task<TeamData> IRequestHandler<Request, TeamData>.Handle(Request request, CancellationToken cancellationToken)
            {
                var result =
                    await db.Teams
                        .SingleOrDefaultAsync(t => t.InternalId == request.TeamId);
 
                return result;
            }
        }


        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(t => t.TeamId).NotNull();
            }
        }
    }
}