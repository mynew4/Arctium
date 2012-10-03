using Db4objects.Db4o;
using Db4objects.Db4o.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Logging;
using System.IO;

namespace DBServer
{
    class DBServer
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("Database"))
                Directory.CreateDirectory("Database");

            using (var server = Db4oClientServer.OpenServer("Database/RealmDB.yap", 8000))
            {
                server.GrantAccess("arctium", "arctium");
                GC.Collect();

                Log.Message(LogType.NORMAL, "RealmDB server sucessfully started...");
                Log.Message(LogType.NORMAL, "Press enter to exit.");

                GC.Collect();
                Console.Read();
            }
        }
    }
}
