namespace Incentives.Services.Membership.API.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Incentives.Services.Membership.API.Queries.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions options)
             : base(options) { }


        public virtual DbSet<TeamData> Teams { get; set; }
        public virtual DbSet<MemberTypeData> MemberTypes { get; set; }
        public virtual DbSet<MemberData> Members { get; set; }
        public virtual DbSet<TeamAssignmentData> TeamAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            builder.ApplyConfiguration(new MemberData());
            builder.ApplyConfiguration(new MemberTypeData());
            builder.ApplyConfiguration(new TeamData());
            builder.ApplyConfiguration(new TeamAssignmentData());


            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName().ToSnakeCase();

                foreach (var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = property.Name.ToSnakeCase();
                }

                foreach (var key in entity.GetKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.Relational().Name = index.Relational().Name.ToSnakeCase();
                }
            }
        }
    }
}