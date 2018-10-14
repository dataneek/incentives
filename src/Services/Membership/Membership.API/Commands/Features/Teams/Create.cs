namespace Incentives.Services.Membership.API.Commands.Features.Teams
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

            public string CommonName { get; set; }
            public string UniqueIdentifier { get; set; }
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
                var model =
                    new Team(request.Id.Value, request.CommonName, request.UniqueIdentifier);

                await session.Add(model);
                await session.Commit();
            }
        }


        public class CommandValidator : AbstractValidator<Request>
        {
            public CommandValidator()
            {
                RuleFor(t => t.CommonName).NotEmpty();
                RuleFor(t => t.UniqueIdentifier);
                RuleFor(t => t.Id).NotNull();
            }
        }
    }
}