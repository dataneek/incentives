namespace Incentives.Services.Incentive.API.Models
{
    using System;

    public class IncentiveComment : Entity
    {
        private IncentiveComment() { }

        public IncentiveComment(Incentive incentive, string comment)
        {
            this.Incentive = incentive ?? throw new ArgumentNullException(nameof(incentive));
            this.Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }


        public Incentive Incentive { get; private set; }
        public long IncentiveId { get; private set; }

        public long IncentiveCommentId { get; private set; }
        public Guid IncentiveCommentExternalId { get; private set; }

        public string Comment { get; private set; }
    }
}