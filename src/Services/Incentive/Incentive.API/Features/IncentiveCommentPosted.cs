namespace Incentives.Services.Incentive.API.Features
{
    using System;

    public class IncentiveCommentPosted
    {
        public Guid IncentiveCommentId { get; set; }
        public string Comment { get; set; }
    }
}