namespace Incentives.Services.Accounting.API.Commands.Features.LedgerAccounts
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CQRSlite.Domain;
    using FluentValidation;
    using Incentives.Services.Accounting.API.Commands.Models;
    using MediatR;

    public class Update
    {
        public class Request : IRequest
        {
            public string CommonName { get; set; }
            public string AccountNumber { get; set; }
            public bool? IsActive { get; set; }

            public Guid? LedgerAccountId { get; set; }
            public int? ExpectedVersionNumber { get; set; }
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
                var model = await
                    session.Get<LedgerAccount>(
                        request.LedgerAccountId.Value, 
                        request.ExpectedVersionNumber, 
                        cancellationToken);

                model.Update(request.CommonName, request.AccountNumber, request.IsActive.Value);

                await session.Commit(cancellationToken);
            }
        }


        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(t => t.CommonName).NotEmpty().Length(2, 50);
                RuleFor(t => t.AccountNumber).NotEmpty().Length(2, 50);
                RuleFor(t => t.LedgerAccountId).NotNull();
            }
        }
    }
}