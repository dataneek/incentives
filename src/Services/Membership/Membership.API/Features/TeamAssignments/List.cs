namespace Incentives.Services.Membership.API.Features.TeamAssignments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;

    public class List
    {
        public class Request : IRequest<IEnumerable<Model>>
        {
            public int? ItemCountPerPage { get; set; }
            public int? PageNumber { get; set; }
            
            public Guid? TeamId { get; set; }
            public string FilterText { get; set; }
        }

        public class Model
        {
            public Guid TeamAssignmentId { get; set; }
            public TeamModel Team { get; set; }
            public MemberModel Member { get; set; }

            public class TeamModel
            {
                public Guid TeamId { get; set; }
                public string CommonName { get; set; }
            }

            public class MemberModel
            {
                public Guid MemberId { get; set; }
                public string CompleteName { get; set; }
            }
        }


        public class RequestHandler : IRequestHandler<Request, IEnumerable<Model>>
        {
            public RequestHandler()
            {

            }

            Task<IEnumerable<Model>> IRequestHandler<Request, IEnumerable<Model>>.Handle(Request request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }


        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {

            }
        }
    }
}