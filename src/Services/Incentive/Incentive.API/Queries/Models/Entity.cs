namespace Incentives.Services.Incentive.API.Queries.Models
{
    using System;

    public abstract class Entity
    {
        public DateTimeOffset CreateAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdateAt { get; set; } = DateTimeOffset.Now;
        public Guid InternalId { get; set; }

        protected void OnUpdate()
        {
            this.UpdateAt = DateTimeOffset.Now;
        }
    }
}