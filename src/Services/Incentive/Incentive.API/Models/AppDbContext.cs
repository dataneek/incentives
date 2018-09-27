namespace Incentives.Services.Incentive.API.Models
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }


        public virtual DbSet<Incentive> Incentives { get; set; }
        public virtual DbSet<IncentiveType> IncentiveTypes { get; set; }
        public virtual DbSet<IncentiveComment> IncentiveComments { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }
        public virtual DbSet<CostCode> CostCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Incentive>()
                .HasKey(t => t.IncentiveId);

            modelBuilder.Entity<IncentiveType>()
                .HasKey(t => t.IncentiveTypeId);

            modelBuilder.Entity<Member>()
                .HasKey(t => t.MemberId);

            modelBuilder.Entity<MemberType>()
                .HasKey(t => t.MemberTypeId);

            modelBuilder.Entity<CostCode>()
                .HasKey(t => t.CostCodeId);

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