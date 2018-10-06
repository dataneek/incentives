namespace Incentives.Services.Accounting.API.Queries
{
    using System.Linq;
    using Incentives.Services.Accounting.API.Queries.Models;

    public interface IReadonlyDatabase
    {
        IQueryable<CostCodeData> CostCodes { get; }
        IQueryable<LedgerAccountData> LedgerAccounts { get; }
    }
}