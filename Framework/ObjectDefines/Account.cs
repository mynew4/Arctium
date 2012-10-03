using Db4objects.Db4o.Linq;
using Framework.Database;
using System.Linq;

namespace Framework.ObjectDefines
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string SessionKey { get; set; }

        public byte SecurityFlags { get; set; }

        public byte Expansion { get; set; }

        public byte GMLevel { get; set; }

        public string IP { get; set; }

        public string Language { get; set; }

        public static Account GetAccountById(uint accId)
        {
            var account = from Account a in DB.RealmDB.Connection where a.Id == accId select a;

            if (account.Count() == 1)
                return account.First();

            return null;
        }

        public static Account GetAccountByName(string name)
        {
            var account = from Account a in DB.RealmDB.Connection where a.Name == name select a;

            if (account.Count() == 1)
                return account.First();

            return null;
        }
    }
}