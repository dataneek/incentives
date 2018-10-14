namespace Incentives.Services.Membership.API.Queries.Features.TeamAssignments
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
        public class Request : IRequest<TeamAssignmentData>
        {
            public Guid? TeamAssignmentId { get; set; }
        }


        public class RequestHandler : IRequestHandler<Request, TeamAssignmentData>
        {
            private readonly IReadonlyDatabase db;

            public RequestHandler(IReadonlyDatabase db)
            {
                this.db = db;
            }

            async Task<TeamAssignmentData> IRequestHandler<Request, TeamAssignmentData>.Handle(Request request, CancellationToken cancellationToken)
            {
                var result =
                    await db.TeamAssignments
                        .SingleOrDefaultAsync(t => t.InternalId == request.TeamAssignmentId);
 
                return result;
            }
        }


        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(t => t.TeamAssignmentId).NotNull();
            }
        }
    }
}