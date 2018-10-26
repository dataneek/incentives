namespace Incentives.Services.Incentive.API.Queries
{
    using System.Linq;
    using Incentives.Services.Incentive.API.Queries.Models;
    using Microsoft.EntityFrameworkCore;

    public class ReadonlyDatabase : IReadonlyDatabase
    {
        private readonly DefaultDbContext db;

        public ReadonlyDatabase(DefaultDbContext db)
        {
            this.db = db;
        }

        IQueryable<IncentiveData> IReadonlyDatabase.Incentives => db.Incentives.AsNoTracking();
        IQueryable<IncentiveTypeData> IReadonlyDatabase.IncentiveTypes => db.IncentiveTypes.AsNoTracking();
        IQueryable<CommentData> IReadonlyDatabase.Comments => db.Comments.AsNoTracking();
    }
}