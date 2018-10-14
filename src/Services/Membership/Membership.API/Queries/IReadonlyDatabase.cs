namespace Incentives.Services.Membership.API.Queries
{
    using System.Linq;
    using Incentives.Services.Membership.API.Queries.Models;

    public interface IReadonlyDatabase
    {
        IQueryable<TeamData> Teams { get; }
        IQueryable<TeamAssignmentData> TeamAssignments { get; }
        IQueryable<MemberTypeData> MemberTypes { get; }
        IQueryable<MemberData> Members { get; }
    }
}