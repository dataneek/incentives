namespace Incentives.Services.Membership.API.Queries.Features.Members
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class About
    {
        public class Request : IRequest<MemberData>
        {
            public Guid? MemberId { get; set; }
        }


        public class RequestHandler : IRequestHandler<Request, MemberData>
        {
            private readonly IReadonlyDatabase db;

            public RequestHandler(IReadonlyDatabase db)
            {
                this.db = db;
            }

            async Task<MemberData> IRequestHandler<Request, MemberData>.Handle(Request request, CancellationToken cancellationToken)
            {
                var result =
                    await db.Members
                        .SingleOrDefaultAsync(t => t.InternalId == request.MemberId);
 
                return result;
            }
        }


        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(t => t.MemberId).NotNull();
            }
        }
    }
}