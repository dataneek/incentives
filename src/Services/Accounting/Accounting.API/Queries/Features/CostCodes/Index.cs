namespace Incentives.Services.Accounting.API.Queries.Features.CostCodes
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FluentValidation;
    using MediatR;
    using Models;
    using PaginableCollections;

    public class Index
    {
        public class Model
        {
            public IPaginable Paginable { get; set; }

            public class Item
            {
                public string CommonName { get; set; }
                public string UniqueIdentifier { get; set; }
                public bool IsActive { get; set; }
            }
        }


        public class Request : IRequest<Model>
        {
            public int? ItemCountPerPage { get; set; }
            public int? PageNumber { get; set; }
        }


        public class RequestHandler : IRequestHandler<Request, Model>
        {
            private readonly IReadonlyDatabase session;
            private readonly IConfigurationProvider configurationProvider;

            public RequestHandler(IReadonlyDatabase session, IConfigurationProvider configurationProvider)
            {
                this.session = session;
                this.configurationProvider = configurationProvider;
            }

            Task<Model> IRequestHandler<Request, Model>.Handle(Request request, CancellationToken cancellationToken)
            {
                var paginable =
                    session.CostCodes
                        .ProjectTo<Model.Item>(configurationProvider)
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

        public class RequestMapper : Profile
        {
            public RequestMapper()
            {
                CreateMap<CostCodeData, Model.Item>();
            }
        }
    }
}