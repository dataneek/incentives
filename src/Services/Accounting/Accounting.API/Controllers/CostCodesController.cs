namespace Incentives.Services.Accounting.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Incentives.Services.Accounting.API.Commands.Features.CostCodes;
    using Incentives.Services.Accounting.API.Queries.Features.CostCodes;

    [ApiController]
    [Route("api/v1/cost-codes")]
    public class CostCodesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CostCodesController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
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


        public class GetRequest
        {
            [FromQuery]
            public int PageNumber { get; set; }

            [FromQuery]
            public int ItemCountPerPage { get; set; }
        }
    }
}