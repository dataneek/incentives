namespace Incentives.Services.Membership.API.Features.MemberTypes
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
                await this.context.MemberTypes.AddAsync(
                    new MemberType(request.CommonName), cancellationToken);
            }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(t => t.CommonName).NotEmpty().Length(2, 50);
            }
        }
    }
}