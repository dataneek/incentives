namespace Incentives.Services.Incentive.API.Models
{
    using System;
    using System.Collections.Generic;

    public class Incentive : Entity
    {
        private Incentive() { }

        public Incentive(Member member, IncentiveType incentiveType, decimal amount)
        {
            this.Member = member ?? throw new ArgumentNullException(nameof(member));
            this.IncentiveType = incentiveType ?? throw new ArgumentNullException(nameof(incentiveType));
            this.CostCode = incentiveType.CostCode;
            this.Amount = amount;
        }


        public Member Member { get; private set; }
        public long MemberId { get; private set; }

        public IncentiveType IncentiveType { get; private set; }
        public long IncentiveTypeId { get; private set; }

        public CostCode CostCode { get; private set; }
        public long CostCodeId { get; private set; }

        public decimal Amount { get; private set; }

        public bool IsSubmitted { get; private set; } = false;
        public bool IsReviewed { get; private set; } = false;
        public bool IsCanceled { get; private set; } = false;
        public bool IsCompleted { get; private set; } = false;
        public DateTimeOffset? CompleteAt { get; private set; } = null;
        public DateTimeOffset? CancelAt { get; private set; } = null;

        public bool IsPaid { get; private set; } = false;
        public DateTimeOffset? PaidAt { get; private set; }

        public long IncentiveId { get; private set; }
        public Guid IncentiveExternalId { get; private set; } = Guid.NewGuid();


        public void Update(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (this.IsSubmitted || this.IsCanceled)
                throw new InvalidOperationException();

            this.Amount = amount;
            OnUpdate();
        }

        public void Cancel()
        {
            this.IsCanceled = true;
            this.CancelAt = DateTimeOffset.Now;

            OnUpdate();
        }

        public void Complete()
        {
            this.IsCompleted = true;

            OnUpdate();
        }

        public void Paid()
        {
            if (IsPaid)
            {
                throw new InvalidOperationException();
            }

            IsPaid = true;
            PaidAt = DateTimeOffset.Now;

            OnUpdate();
        }
    }
}