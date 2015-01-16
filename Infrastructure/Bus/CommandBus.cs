using System;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Infrastructure.Commands;
using ServiceStack;

namespace Infrastructure.Bus
{
    public class CommandBus : ICommandBus
    {
        private static readonly ServiceClientBase ServiceClient = new JsonServiceClient("http://localhost:21877");
        public CommandResult Excute<T>(T command) where T : ICommand
        {
            try
            {
                return  ServiceClient.Send(command);
            }
            catch (DbUpdateException e)
            {
                //log.save(...)
                throw new Exception(e.Message);
            }
            //MoreException
            catch (Exception e)
            {
                //log.save(...)
                throw new Exception(e.Message);
            }
        }
        public async Task<CommandResult> ExcuteAsync<T>(T command) where T : ICommand
        {
            try
            {
                return await ServiceClient.SendAsync(command);
            }
            catch (DbUpdateException e)
            {
                //log.save(...)
                throw new Exception(e.Message);
            }
            //MoreException
            catch (Exception e)
            {
                //log.save(...)
                throw new Exception(e.Message);
            }
        }
    }
}