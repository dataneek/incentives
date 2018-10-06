namespace Incentives.Services.Accounting.API.Commands.Features.CostCodes
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Models;

    public class Update
    {
        public class Request : IRequest
        {
            public string CommonName { get; set; }
            public string UniqueIdentifier { get; set; }
            public bool? IsActive { get; set; }
            public Guid? CodeCodeId { get; set; }
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
                    session.GetAsync<CostCode>(
                        request.CodeCodeId.Value, 
                        request.ExpectedVersionNumber, 
                        cancellationToken);

                model.Update(request.CommonName, request.UniqueIdentifier, request.IsActive.Value);

                await session.CommitAsync(cancellationToken);
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