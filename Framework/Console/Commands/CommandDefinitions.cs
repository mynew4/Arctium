namespace Framework.Console.Commands
{
    public class CommandDefinitions
    {
        public static void InitializeRealmCommands()
        {
            CommandManager.DefineCommand("caccount", AccountCommands.CreateAccount);
            CommandManager.DefineCommand("crealm", RealmsCommands.CreateRealm);
        }

        public static void InitializeWorldCommands()
        {
        }
    }
}
