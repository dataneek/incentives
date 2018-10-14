namespace Incentives.Services.Membership.API.Models
{
    using System;
    using CQRSlite.Domain;
    using Incentives.Services.Membership.API.Commands.Events;

    public class Member : AggregateRoot
    {
        private Member() { }

        public Member(Guid id, Guid memberTypeId, string completeName, string sortableName, string memberNumber)
        {
            this.Id = id;
            ApplyChange(new MemberCreated(id, memberTypeId, completeName, sortableName, memberNumber));
        }


        public Guid MemberTypeId { get; private set; }

        public string CompleteName { get; private set; }
        public string SortableName { get; private set; }
        public string MemberNumber { get; private set; }
        public bool IsActive { get; private set; } = true;


        public void Update(Guid memberTypeId, string completeName, string sortableName, string memberNumber, bool isActive)
        {
            ApplyChange(new MemberUpdated(this.Id, memberTypeId, completeName, sortableName, memberNumber, isActive));
        }

        private void Apply(MemberCreated e)
        {
            if (e.MemberTypeId == Guid.Empty)
                MemberTypeId = e.MemberTypeId;

            this.CompleteName = e.CompleteName ?? throw new ArgumentNullException(nameof(e.CompleteName));
            this.SortableName = e.SortableName;
            this.MemberNumber = e.MemberNumber ?? throw new ArgumentNullException(nameof(e.MemberNumber));
        }

        private void Apply(MemberUpdated e)
        {
            if (e.MemberTypeId == Guid.Empty)
                MemberTypeId = e.MemberTypeId;

            this.CompleteName = e.CompleteName ?? throw new ArgumentNullException(nameof(e.CompleteName));
            this.SortableName = e.SortableName;
            this.MemberNumber = e.MemberNumber ?? throw new ArgumentNullException(nameof(e.MemberNumber));
            this.IsActive = e.IsActive;
        }
    }
}