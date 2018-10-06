namespace Incentives.Services.Accounting.API.Models
{
    using System;

    public class ConcurrencyException : Exception
    {
        public ConcurrencyException(Guid id)
            : base($"A different version than expected was found in aggregate {id}") { }
    }
}