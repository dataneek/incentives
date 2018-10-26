namespace Incentives.Services.Incentive.API.Commands.Models
{
    using System;
    using CQRSlite.Domain;
    using Events;

    public class Comment : AggregateRoot
    {
        private Comment() { }

        public Comment(Guid id, Guid incentiveId, Guid memberId, string commentBody)
        {
            this.Id = id;
            ApplyChange(new CommentPosted(this.Id, incentiveId, memberId, commentBody));
        }


        public Guid IncentiveId { get; private set; }
        public Guid MemberId { get; private set; }

        public string CommentBody { get; private set; }
        public DateTimeOffset PostAt { get; private set; }


        private void Apply(CommentPosted e)
        {
            this.MemberId = e.MemberId;
            this.IncentiveId = e.IncentiveId;
            this.CommentBody = e.CommentBody;
            this.PostAt = e.PostAt;
        }
    }
}