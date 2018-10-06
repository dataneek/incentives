namespace Incentives.Services.Accounting.API.Queries
{
    using System.Linq;
    using Incentives.Services.Accounting.API.Queries.Models;
    using Microsoft.EntityFrameworkCore;

    public class ReadonlyDatabase : IReadonlyDatabase
    {
        private readonly DefaultDbContext db;

        public ReadonlyDatabase(DefaultDbContext db)
        {
            this.db = db;
        }

        IQueryable<CostCodeData> IReadonlyDatabase.CostCodes => db.CostCodes.AsNoTracking();
        IQueryable<LedgerAccountData> IReadonlyDatabase.LedgerAccounts => db.LedgerAccounts.AsNoTracking();
    }
}