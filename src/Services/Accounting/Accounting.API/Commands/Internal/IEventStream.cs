namespace Incentives.Services.Accounting.API.Commands
{
    using System.Collections.Generic;
    using CQRSlite.Events;

    public interface IEventStream : IList<IEvent>
    {

    }
}