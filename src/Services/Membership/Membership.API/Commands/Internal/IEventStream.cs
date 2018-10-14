namespace Incentives.Services.Membership.API.Commands
{
    using System.Collections.Generic;
    using CQRSlite.Events;

    public interface IEventStream : IList<IEvent>
    {

    }
}