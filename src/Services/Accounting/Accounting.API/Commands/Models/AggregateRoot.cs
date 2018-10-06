namespace Incentives.Services.Accounting.API.Commands.Models
{
    using Incentives.Services.Accounting.API.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class AggregateRoot
    {
        private readonly List<IEvent> changesets = new List<IEvent>();

        public Guid Id { get; protected set; }
        public int VersionNumber { get; protected set; }


        public IEvent[] GetUncommittedChanges()
        {
            lock (changesets)
            {
                return changesets.ToArray();
            }
        }

        public IEvent[] FlushUncommittedChanges()
        {
            lock (changesets)
            {
                var changes = changesets.ToArray();
                var i = 0;
                foreach (var @event in changes)
                {
                    if (@event.Id == Guid.Empty && Id == Guid.Empty)
                    {
                        throw new Exception();
                        //throw new AggregateOrEventMissingIdException(GetType(), @event.GetType());
                    }
                    if (@event.Id == Guid.Empty)
                    {
                        @event.Id = Id;
                    }
                    i++;
                    @event.VersionNumber = VersionNumber + i;
                    @event.CreatedAt = DateTimeOffset.UtcNow;
                }
                VersionNumber = VersionNumber + changes.Length;
                changesets.Clear();

                return changes;
            }
        }

        public void LoadFromHistory(IEnumerable<IEvent> history)
        {
            lock (changesets)
            {
                foreach (var e in history.ToArray())
                {
                    if (e.VersionNumber != VersionNumber + 1)
                    {
                        throw new Exception();
                        //throw new EventsOutOfOrderException(e.Id);
                    }

                    ApplyEvent(e);
                    Id = e.Id;
                    VersionNumber++;
                }
            }
        }

        protected virtual void ApplyEvent(IEvent e)
        {
            this.Invoke("Apply", e);
        }


        protected void RaiseEvent(IEvent e)
        {
            lock (changesets)
            {
                ApplyEvent(e);
                changesets.Add(e);
            }
        }
    }
}