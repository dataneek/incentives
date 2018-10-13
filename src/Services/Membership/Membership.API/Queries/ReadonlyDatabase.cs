namespace Incentives.Services.Membership.API.Queries
{
    using System.Linq;
    using Incentives.Services.Membership.API.Queries.Models;
    using Microsoft.EntityFrameworkCore;

    public class ReadonlyDatabase : IReadonlyDatabase
    {
        private readonly DefaultDbContext db;

        public ReadonlyDatabase(DefaultDbContext db)
        {
            this.db = db;
        }

        IQueryable<TeamData> IReadonlyDatabase.Teams => db.Teams.AsNoTracking();
        IQueryable<TeamAssignmentData> IReadonlyDatabase.TeamAssignments => db.TeamAssignments.AsNoTracking();
        IQueryable<MemberData> IReadonlyDatabase.Members => db.Members.AsNoTracking();
        IQueryable<MemberTypeData> IReadonlyDatabase.MemberTypes => db.MemberTypes.AsNoTracking();
    }
}