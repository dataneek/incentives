namespace Incentives.Services.Membership.API.Features.TeamAssignments
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
            public Guid? TeamId { get; set; }
            public Guid? MemberTypeId { get; set; }
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
                throw new InvalidOperationException();
            }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(t => t.TeamId).NotEmpty();
                RuleFor(t => t.MemberTypeId).NotNull();
            }
        }
    }
}