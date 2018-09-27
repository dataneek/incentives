namespace Incentives.Services.Incentive.API.Models
{
    using System;

    public class MemberType
    {
        private MemberType() { }

        public MemberType(string commonName)
        {
            this.CommonName = commonName;
        }


        public long MemberTypeId { get; private set; }
        public Guid MemberTypeExternalId { get; private set; }

        public string CommonName { get; private set; }
    }
}