namespace Incentives.Services.Incentive.API.Commands.Models
{
    using System;
    using CQRSlite.Domain;
    using Events;

    public class Incentive : AggregateRoot
    {
        private Incentive() { }

        public Incentive(Guid id, Guid incentiveTypeId, Guid memberId, decimal incentiveAmount)
        {
            this.Id = id;
            ApplyChange(new IncentiveCreated(id, incentiveTypeId, memberId, incentiveAmount));
        }


        public Guid MemberId { get; private set; }
        public Guid IncentiveTypeId { get; private set; }

        public decimal IncentiveAmount { get; private set; }

        public bool IsSubmitted { get; private set; } = false;
        public bool IsReviewed { get; private set; } = false;
        public bool IsCanceled { get; private set; } = false;
        public bool IsCompleted { get; private set; } = false;

        public DateTimeOffset? CompleteAt { get; private set; } = null;
        public DateTimeOffset? CancelAt { get; private set; } = null;

        public bool IsPaid { get; private set; } = false;
        public DateTimeOffset? PaidAt { get; private set; } = null;


        public void Update(decimal incentiveAmount)
        {
            if (IsSubmitted)
                throw new InvalidOperationException("Cannot update after incentive is submitted.");

            ApplyChange(new IncentiveUpdated(this.Id, incentiveAmount));
        }

        public void Cancel()
        {
            ApplyChange(new IncentiveCanceled(this.Id));
        }

        public void Complete()
        {
            ApplyChange(new IncentiveCanceled(this.Id));
        }

        public void Paid()
        {
            ApplyChange(new IncentivePaid(this.Id));
        }

        private void Apply(IncentiveCreated e)
        {
            this.MemberId = e.MemberId;
            this.IncentiveTypeId = e.IncentiveTypeId;
            this.IncentiveAmount = e.IncentiveAmount;
        }

        private void Apply(IncentiveUpdated e)
        {
            this.IncentiveAmount = e.IncentiveAmount;
        }

        private void Apply(IncentiveSubmitted e)
        {
            this.IsSubmitted = true;
        }

        private void Apply(IncentivePaid e)
        {
            this.IsPaid = true;
        }

        private void Apply(IncentiveCanceled e)
        {
            this.IsCanceled = true;
        }
    }
}