namespace Incentives.Services.Membership.API.Models
{
    using System;

    public class MemberType : Entity
    {
        private MemberType() { }

        public MemberType(string commonName)
        {
            this.CommonName = commonName ?? throw new ArgumentNullException(nameof(commonName));
        }


        public string CommonName { get; private set; }

        public long MemberTypeId { get; private set; }
        public Guid MemberTypeExternalId { get; private set; }

        public bool IsDeleted { get; private set; }


        public void Update(string commonName)
        {
            this.CommonName = commonName ?? throw new ArgumentNullException(nameof(commonName));
            OnUpdate();
        }

        public void MarkAsDeleted()
        {
            this.IsDeleted = true;
            OnUpdate();
        }
    }
}