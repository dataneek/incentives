namespace Incentives.Services.Membership.API.Features.MemberTypes
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class Update
    {
        public class Command : IRequest
        {
            public Guid CommandId { get; set; }
            public Guid MemberTypeId { get; set; }
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
                var entity =
                    await this.context.MemberTypes
                        .SingleAsync(t => t.MemberTypeExternalId == request.MemberTypeId);

                entity.Update(
                    request.CommonName);       
            }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(t => t.CommonName).NotEmpty().Length(2, 50);
                RuleFor(t => t.MemberTypeId).NotNull();
            }
        }
    }
}