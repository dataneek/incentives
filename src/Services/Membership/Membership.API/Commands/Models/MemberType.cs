namespace Incentives.Services.Membership.API.Models
{
    using System;
    using CQRSlite.Domain;
    using Incentives.Services.Membership.API.Commands.Events;

    public class MemberType : AggregateRoot
    {
        private MemberType() { }

        public MemberType(Guid id, string commonName)
        {
            this.Id = id;
            ApplyEvent(new MemberTypeCreated(this.Id, commonName));
        }


        public string CommonName { get; private set; }
        public bool IsActive { get; private set; } = true;


        public void Update(string commonName, bool isActive)
        {
            ApplyEvent(new MemberTypeUpdated(this.Id, commonName, isActive));
        }

        private void Apply(MemberTypeCreated e)
        {
            this.CommonName = e.CommonName ?? throw new ArgumentNullException(nameof(e.CommonName));
        }

        private void Apply(MemberTypeUpdated e)
        {
            this.CommonName = e.CommonName ?? throw new ArgumentNullException(nameof(e.CommonName));
            this.IsActive = e.IsActive;
        }
    }
}