namespace Incentives.Services.Membership.API.Commands.Features.TeamAssignments
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CQRSlite.Domain;
    using FluentValidation;
    using MediatR;
    using Models;

    public class Create
    {
        public class Request : IRequest
        {
            public Guid? Id { get; set; }
            public Guid? CommandId { get; set; }

            public Guid? TeamId { get; set; }
            public Guid? MemberId { get; set; }
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
                var team = await
                    session.Get<Team>(request.TeamId.Value, cancellationToken: cancellationToken);

                if (team == null)
                    throw new ArgumentNullException(nameof(team));

                var member = await
                    session.Get<Member>(request.MemberId.Value, cancellationToken: cancellationToken);

                if (member == null)
                    throw new ArgumentNullException(nameof(member));

                var teamMember = new TeamAssignment(request.Id.Value, request.TeamId.Value, request.MemberId.Value);

                await session.Add(teamMember);
                await session.Commit();
            }
        }


        public class CommandValidator : AbstractValidator<Request>
        {
            public CommandValidator()
            {
                RuleFor(t => t.TeamId).NotEmpty();
                RuleFor(t => t.MemberId).NotNull();
                RuleFor(t => t.Id).NotNull();
            }
        }
    }
}