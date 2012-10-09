namespace Framework.Console.Commands
{
    public class CommandDefinitions
    {
        public static void Initialize()
        {
            CommandManager.DefineCommand("caccount", AccountCommands.CreateAccount);
        }
    }
}
