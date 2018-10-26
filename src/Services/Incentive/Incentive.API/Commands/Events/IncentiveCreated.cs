namespace Incentives.Services.Incentive.API.Commands.Events
{
    using System;
    using MediatR;

    public class IncentiveCreated : EventBase, INotification
    {
        private IncentiveCreated() { }

        public IncentiveCreated(Guid id, Guid incentiveTypeId, Guid memberId, decimal incentiveAmount)
        {
            this.Id = id;
            this.IncentiveTypeId = incentiveTypeId;
            this.MemberId = memberId;
            this.IncentiveAmount = incentiveAmount;
        }

        public Guid IncentiveTypeId { get; private set; }
        public Guid MemberId { get; set; }
        public decimal IncentiveAmount { get; set; }
    }
}