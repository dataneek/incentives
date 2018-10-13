namespace Incentives.Services.Membership.API.Queries.Features.MemberTypes
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
        public class Request : IRequest<MemberTypeData>
        {
            public Guid? MemberTypeId { get; set; }
        }


        public class RequestHandler : IRequestHandler<Request, MemberTypeData>
        {
            private readonly IReadonlyDatabase db;

            public RequestHandler(IReadonlyDatabase db)
            {
                this.db = db;
            }

            async Task<MemberTypeData> IRequestHandler<Request, MemberTypeData>.Handle(Request request, CancellationToken cancellationToken)
            {
                var result =
                    await db.MemberTypes
                        .SingleOrDefaultAsync(t => t.InternalId == request.MemberTypeId);
 
                return result;
            }
        }


        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(t => t.MemberTypeId).NotNull();
            }
        }
    }
}