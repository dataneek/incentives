namespace Incentives.Services.Incentive.API.Features
{
    using System;

    public class IncentiveCreated
    {
        public Guid IncentiveId { get; set; }
        public decimal Amount { get; set; }
    }
}