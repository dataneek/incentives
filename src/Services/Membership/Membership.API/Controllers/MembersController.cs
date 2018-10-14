namespace Incentives.Services.Membership.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Incentives.Services.Membership.API.Commands.Features.Members;
    using Incentives.Services.Membership.API.Queries.Features.Members;
    using System;

    [ApiController]
    [Route("api/v1/membership/members")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator mediator;

        public MembersController(IMediator mediator)
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
        public async Task<IActionResult> Get(Guid? memberId)
        {
            var result =
                await this.mediator.Send(
                    new About.Request
                    {
                        MemberId = memberId
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