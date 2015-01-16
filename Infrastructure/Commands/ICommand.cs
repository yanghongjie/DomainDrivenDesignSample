using System;
using ServiceStack;

namespace Infrastructure.Commands
{
    public interface ICommand : IReturn<CommandResult>
    {
        Guid CommandId { get; }
    }
}
