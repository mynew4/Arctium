using Framework.Database;
using Framework.ObjectDefines;
using Framework.Logging;

namespace Framework.Console.Commands
{
    public class AccountCommands : CommandParser
    {
        public static void CreateAccount(string[] args)
        {
            string name = Read<string>(args, 0).ToUpper();
            string password = Read<string>(args, 1);

            if (name == null || password == null)
                return;

            //byte[] hash = new SHA1CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(password));
            //string hashString = BitConverter.ToString(hash).Replace("-", "");

            SQLResult result = DB.Realms.Select("SELECT * FROM accounts WHERE name = '{0}'", name);
            if (result.Count == 0)
            {
                if (DB.Realms.Execute("INSERT INTO accounts (name, password, language) VALUES ('{0}', '{1}', '')", name, password.ToUpper()))
                    Log.Message(LogType.NORMAL, "Account {0} successfully created", name);
            }
            else
                Log.Message(LogType.ERROR, "Account {0} already in database", name);
        }
    }
}
