using System.Threading.Tasks;
using Application.Services.Config;
using Domain.Commands;
using Infrastructure.Commands;
using ServiceStack;

namespace Application.Services
{
    public partial class CommandService : Service
    {
        public async Task<CommandResult> Any(BuildOrder command)
        {
            return await Handler(command);
        }
    }
}