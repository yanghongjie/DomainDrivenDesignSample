using System;

namespace Infrastructure.Commands
{
    [Serializable]
    public abstract class Command : ICommand
    {
        protected Command()
        {
            this.CommandId = Guid.NewGuid();
        }

        public Guid CommandId { get; set; }
    }
}