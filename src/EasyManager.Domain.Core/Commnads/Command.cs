using System;
using EasyManager.Domain.Core.Events;
using FluentValidation.Results;
using MediatR;

namespace EasyManager.Domain.Core.Commands
{
    public abstract class Command<T> : Message<T>
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }

        public abstract bool IsValid();
    }

    public abstract class Command : Command<Unit>
    {
        
    }
}