namespace Incentives.Services.Incentive.API.Queries
{
    using Incentives.Services.Incentive.API.Queries.Models;
    using Microsoft.EntityFrameworkCore;

    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions options)
             : base(options) { }


        public virtual DbSet<IncentiveData> Incentives { get; set; }
        public virtual DbSet<IncentiveTypeData> IncentiveTypes { get; set; }
        public virtual DbSet<CommentData> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IncentiveData());
            builder.ApplyConfiguration(new IncentiveTypeData());
            builder.ApplyConfiguration(new CommentData());
        }
    }
}