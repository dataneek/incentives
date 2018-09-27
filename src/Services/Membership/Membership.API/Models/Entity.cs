namespace Incentives.Services.Membership.API.Models
{
    using System;

    public abstract class Entity
    {
        public DateTimeOffset CreateAt { get; private set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdateAt { get; private set; } = DateTimeOffset.Now;

        protected void OnUpdate()
        {
            this.UpdateAt = DateTimeOffset.Now;
        }
    }
}