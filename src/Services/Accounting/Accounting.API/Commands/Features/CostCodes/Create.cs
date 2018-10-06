namespace Incentives.Services.Accounting.API.Commands.Features.CostCodes
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Models;

    public class Create
    {
        public class Request : IRequest
        {
            public string CommonName { get; set; }
            public string UniqueIdentifier { get; set; }
            public Guid? CodeCodeId { get; set; }
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
                var aggregate = 
                    new CostCode(request.CodeCodeId.Value, request.CommonName, request.UniqueIdentifier);

                await session.AddAsync(aggregate);
                await session.CommitAsync();
            }
        }


        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(t => t.CommonName).NotEmpty().Length(2, 50);
                RuleFor(t => t.UniqueIdentifier).NotEmpty().Length(2, 50);
                RuleFor(t => t.CodeCodeId).NotNull();
            }
        }
    }
}