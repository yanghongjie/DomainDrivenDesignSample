namespace Infrastructure.Commands
{
    public class CommandResult
    {
        public CommandResult()
        {
        }

        public CommandResult(bool result = true,string msg = "")
        {
            this.Result = result;
            this.Msg = msg;
        }

        public bool Result { get; set; }
        public string Msg { get; set; } 
    }
}