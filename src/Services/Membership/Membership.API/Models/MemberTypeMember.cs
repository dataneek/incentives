namespace Incentives.Services.Membership.API.Models
{
    using System;

    public class MemberTypeMember : Entity
    {
        private MemberTypeMember() { }

        public MemberTypeMember(MemberType memberType, Member member)
        {
            MemberType = memberType ?? throw new ArgumentNullException(nameof(memberType));
            Member = member ?? throw new ArgumentNullException(nameof(member));
        }


        public long MemberTypeMemberId { get; private set; }
        public Guid MemberTypeMemberExternalId { get; private set; } = Guid.NewGuid();

        public MemberType MemberType { get; private set; }
        public long MemberTypeId { get; private set; }

        public Member Member { get; private set; }
        public long MemberId { get; private set; }

        public DateTimeOffset AssignedAt { get; private set; } = DateTimeOffset.Now;
        public bool IsDeleted { get; private set; } = false;
    }
}