using System;
using OnlineHotel.Infra.Domain.Core.Events;
using FluentValidation.Results;

namespace OnlineHotel.Infra.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}