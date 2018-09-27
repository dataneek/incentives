namespace Incentives.Services.Incentive.API.Models
{
    using System;

    public class Member 
    {
        private Member() { }

        public Member(MemberType memberType, string commonName)
        {
            MemberType = memberType ?? throw new ArgumentNullException(nameof(memberType));
            CommonName = commonName ?? throw new ArgumentNullException(nameof(commonName));
        }


        public long MemberTypeId { get; private set; }
        public MemberType MemberType { get; private set; }

        public string CommonName { get; private set; }

        public long MemberId { get; private set; }
        public Guid MemberExternalId { get; private set; } = Guid.NewGuid();
    }
}