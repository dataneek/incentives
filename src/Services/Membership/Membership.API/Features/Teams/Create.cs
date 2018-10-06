namespace Incentives.Services.Membership.API.Features.Teams
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Models;

    public class Create
    {
        public class Command : IRequest
        {
            public Guid? CommandId { get; set; }
            public string CommonName { get; set; }
            public string TeamNumber { get; set; }
        }


        public class CommandHandler : AsyncRequestHandler<Command>
        {
            private readonly AppDbContext context;

            public CommandHandler(AppDbContext context)
            {
                this.context = context;
            }

            protected override async Task Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(t => t.CommonName).NotEmpty();
                RuleFor(t => t.TeamNumber);
            }
        }
    }
}