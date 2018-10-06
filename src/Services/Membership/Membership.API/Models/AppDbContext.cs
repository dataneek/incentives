namespace Incentives.Services.Membership.API.Models
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }


        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }

        public virtual DbSet<MemberTypeAssignment> MemberTypeMembers { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>()
                .HasKey(t => t.TeamId);

            modelBuilder.Entity<Member>()
                .HasKey(t => t.MemberId);

            modelBuilder.Entity<MemberType>()
                .HasKey(t => t.MemberTypeId);

            modelBuilder.Entity<MemberTypeAssignment>()
                .HasKey(t => t.MemberTypeAssignmentId);

            modelBuilder.Entity<TeamMember>()
                .HasKey(t => t.TeamMemberId);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();
          
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