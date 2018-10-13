namespace Incentives.Services.Membership.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Incentives.Services.Membership.API.Commands.Features.Teams;
    using Incentives.Services.Membership.API.Queries.Features.Teams;
    using System;

    [ApiController]
    [Route("api/v1/membership/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TeamsController(IMediator mediator)
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
        public async Task<IActionResult> Get(Guid? teamId)
        {
            var result =
                await this.mediator.Send(
                    new About.Request
                    {
                        TeamId = teamId
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

        [HttpPut]
        public async Task<IActionResult> Put(Update.Request request)
        {
            var result =
                await this.mediator.Send(request);

            return Ok();
        }
    }
}