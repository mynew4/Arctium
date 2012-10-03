using Framework.Database;
using Framework.Logging;
using Framework.ObjectDefines;

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

            Account acc = new Account();

            acc.Name = name;
            acc.Password = password;
            acc.Language = "enUS";

            var result = Account.GetAccountByName(name);
            acc.Id = DB.RealmDB.RowCount + 1;

            if (result == null)
            {
                DB.RealmDB.Save(acc);
                Log.Message(LogType.NORMAL, "Account {0} successfully created", name);
            }
            else
                Log.Message(LogType.ERROR, "Account {0} already in database", name);
        }
    }
}
