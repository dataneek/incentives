namespace Incentives.Services.Membership.API.Models
{
    using System;

    public class Member : Entity
    {
        private Member() { }

        public Member(MemberType memberType, string completeName, string sortableName, string memberNumber)
        {
            MemberType = memberType ?? throw new ArgumentNullException(nameof(memberType));
            CompleteName = completeName ?? throw new ArgumentNullException(nameof(completeName));
            SortableName = sortableName;
            MemberNumber = memberNumber ?? throw new ArgumentNullException(nameof(memberNumber));
        }


        public long MemberTypeId { get; private set; }
        public MemberType MemberType { get; private set; }

        public string CompleteName { get; private set; }
        public string SortableName { get; private set; }
        public string MemberNumber { get; private set; }

        public bool IsActive { get; private set; } = true;

        public long MemberId { get; private set; }
        public Guid MemberExternalId { get; private set; }


        public void Update(MemberType memberType, string completeName, string sortableName, string memberNumber, bool isActive)
        {
            MemberType = memberType ?? throw new ArgumentNullException(nameof(memberType));
            CompleteName = completeName ?? throw new ArgumentNullException(nameof(completeName));
            SortableName = sortableName;
            MemberNumber = memberNumber ?? throw new ArgumentNullException(nameof(memberNumber));
            IsActive = isActive;

            OnUpdate();
        }
    }
}