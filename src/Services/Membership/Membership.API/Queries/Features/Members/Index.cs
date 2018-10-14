namespace Incentives.Services.Membership.API.Queries.Features.Members
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using Models;
    using PaginableCollections;

    public class Index
    {
        public class Model
        {
            public IPaginable<MemberData> Paginable { get; set; }
        }


        public class Request : IRequest<Model>
        {
            public int? ItemCountPerPage { get; set; }
            public int? PageNumber { get; set; }
        }


        public class RequestHandler : IRequestHandler<Request, Model>
        {
            private readonly IReadonlyDatabase db;
            private readonly IConfigurationProvider configurationProvider;

            public RequestHandler(IReadonlyDatabase db, IConfigurationProvider configurationProvider)
            {
                this.db = db;
                this.configurationProvider = configurationProvider;
            }

            Task<Model> IRequestHandler<Request, Model>.Handle(Request request, CancellationToken cancellationToken)
            {
                var paginable =
                    db.Members
                        .ToPaginable(request.PageNumber.Value, request.ItemCountPerPage.Value);

                return Task.FromResult<Model>(new Model { Paginable = paginable });
            }
        }


        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(t => t.PageNumber).GreaterThanOrEqualTo(1);
                RuleFor(t => t.ItemCountPerPage).GreaterThanOrEqualTo(1);
            }
        }
    }
}