namespace Incentives.Services.Accounting.API.Commands
{
    using System;
    using MediatR;

    public interface IEvent : INotification
    {
        Guid Id { get; set; }
        int VersionNumber { get; set; }
        DateTimeOffset CreatedAt { get; set; }
    }
}