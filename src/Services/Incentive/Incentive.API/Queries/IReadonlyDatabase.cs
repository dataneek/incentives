namespace Incentives.Services.Incentive.API.Queries
{
    using System.Linq;
    using Incentives.Services.Incentive.API.Queries.Models;

    public interface IReadonlyDatabase
    {
        IQueryable<IncentiveData> Incentives { get; }
        IQueryable<IncentiveTypeData> IncentiveTypes { get; }
        IQueryable<CommentData> Comments { get; }
    }
}