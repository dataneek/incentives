namespace Incentives.Services.Accounting.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;

    [ApiController]
    [Route("api/ledger-accounts")]
    public class LedgerAccountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public LedgerAccountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}