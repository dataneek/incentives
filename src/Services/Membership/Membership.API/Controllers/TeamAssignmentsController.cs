namespace Incentives.Services.Membership.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Incentives.Services.Membership.API.Commands.Features.TeamAssignments;
    using Incentives.Services.Membership.API.Queries.Features.TeamAssignments;
    using System;

    [ApiController]
    [Route("api/v1/membership/team-assignments")]
    public class TeamsAssignmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TeamsAssignmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet, Route("page")]
        public async Task<IActionResult> Get(int pageNumber, int itemCountPerPage)
        {
            var result =
                await this.mediator.Send(
                    new Index.Request
                    {
                        PageNumber = pageNumber,
                        ItemCountPerPage = itemCountPerPage,
                    });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid? teamAssignmentId)
        {
            var result =
                await this.mediator.Send(
                    new About.Request
                    {
                        TeamAssignmentId = teamAssignmentId
                    });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Create.Request request)
        {
            var result = 
                await this.mediator.Send(request);

            return Ok(result);
        }

        [HttpPut, Route("cancel")]
        public async Task<IActionResult> Post(Cancel.Request request)
        {
            var result =
                await this.mediator.Send(request);

            return Ok();
        }
    }
}