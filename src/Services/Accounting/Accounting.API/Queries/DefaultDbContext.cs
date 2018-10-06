namespace Incentives.Services.Accounting.API.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Incentives.Services.Accounting.API.Queries.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions options)
            : base(options) { }


        public virtual DbSet<CostCodeData> CostCodes { get; set; }
        public virtual DbSet<LedgerAccountData> LedgerAccounts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CostCodeData>()
                .ToTable("cost_code", "dbo")
                .HasKey(t => t.CostCodeId).HasName("cost_code_id");

            builder.Entity<LedgerAccountData>()
                .ToTable("ledger_account", "dbo")
                .HasKey(t => t.LedgerAccountId).HasName("ledger_account_id");

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