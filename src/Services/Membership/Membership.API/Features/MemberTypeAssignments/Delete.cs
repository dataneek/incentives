namespace Incentives.Services.Membership.API.Features.MemberTypeAssignments
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class Delete
    {
        public class Command : IRequest
        {
            public Guid? CommandId { get; set; }
            public Guid? MemberTypeAssignmentId { get; set; }
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
                RuleFor(t => t.MemberTypeAssignmentId).NotNull();
            }
        }
    }
}