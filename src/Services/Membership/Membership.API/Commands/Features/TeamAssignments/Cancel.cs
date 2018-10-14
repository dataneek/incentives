namespace Incentives.Services.Membership.API.Commands.Features.TeamAssignments
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CQRSlite.Domain;
    using FluentValidation;
    using MediatR;
    using Models;

    public class Cancel
    {
        public class Request : IRequest
        {
            public Guid? CommandId { get; set; }
            public Guid? Id { get; set; }
        }


        public class RequestHandler : AsyncRequestHandler<Request>
        {
            private readonly ISession session;

            public RequestHandler(ISession session)
            {
                this.session = session;
            }

            protected override async Task Handle(Request request, CancellationToken cancellationToken)
            {
                var teamAssignment =
                    await session.Get<TeamAssignment>(request.Id.Value, cancellationToken: cancellationToken);
                  
                if (teamAssignment == null)
                    throw new ArgumentNullException(nameof(teamAssignment));

                teamAssignment.CancelAssignment();

                await session.Commit(cancellationToken);
            }
        }


        public class CommandValidator : AbstractValidator<Request>
        {
            public CommandValidator()
            {
                RuleFor(t => t.Id).NotNull();
            }
        }
    }
}