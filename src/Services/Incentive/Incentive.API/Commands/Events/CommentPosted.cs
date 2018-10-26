namespace Incentives.Services.Incentive.API.Commands.Events
{
    using System;
    using MediatR;

    public class CommentPosted : EventBase, INotification
    {
        private CommentPosted() { }

        public CommentPosted(Guid id, Guid incentiveId, Guid memberId, string commentBody)
        {
            this.Id = id;

            this.MemberId = memberId;
            this.CommentBody = commentBody;
            this.PostAt = DateTimeOffset.Now;
        }

        public Guid IncentiveId { get; private set; }
        public Guid MemberId { get; private set; }
        public string CommentBody { get; private set; }
        public DateTimeOffset PostAt { get; private set; }
    }
}