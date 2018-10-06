namespace Incentives.Services.Membership.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/membership/member-types")]
    [ApiController]
    public class MemberTypesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MemberTypesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> Create([FromBody]CreateRequest request)
        {

            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{member_type_id}")]
        public Task<IActionResult> Update(Guid member_type_id, [FromBody]UpdateRequest request)
        {

            throw new NotImplementedException();
        }



        public class CreateRequest
        {
            public Guid command_id { get; set; }
            public string common_name { get; set; }
        }

        public class UpdateRequest
        {
            public string common_name { get; set; }
            public bool? is_active { get; set; }
        }
    }
}