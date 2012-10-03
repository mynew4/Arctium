using Framework.Console;
using Framework.Console.Commands;
using Framework.Database;
using Framework.Logging;
using Framework.Network.Realm;
using Framework.ObjectDefines;
using System;

namespace RealmServer
{
    class RealmServer
    {
        static void Main(string[] args)
        {
            Log.Message(LogType.INIT, "___________________________________________");
            Log.Message(LogType.INIT, "    __                                     ");
            Log.Message(LogType.INIT, "    / |                     ,              ");
            Log.Message(LogType.INIT, "---/__|---)__----__--_/_--------------_--_-");
            Log.Message(LogType.INIT, "  /   |  /   ) /   ' /    /   /   /  / /  )");
            Log.Message(LogType.INIT, "_/____|_/_____(___ _(_ __/___(___(__/_/__/_");
            Log.Message(LogType.INIT, "___________________________________________");
            Log.Message();

            Log.Message(LogType.NORMAL, "Starting Arctium RealmServer...");

            RealmClass.realm = new RealmNetwork();

            DB.RealmDB.Connect("127.0.0.1", 8000, "arctium", "arctium");

            // Add realms from database.
            Log.Message(LogType.NORMAL, "Updating Realm List..."); 
            Log.Message();
            var result = DB.RealmDB.Select<Realm>();
            foreach (Realm r in result)
            {
                RealmClass.Realms.Add(new Framework.ObjectDefines.Realm()
                {
                    Id = r.Id,
                    Name = r.Name,
                    IP = r.IP,
                    Port = r.Port,
                });

                Log.Message(LogType.NORMAL, "Added Realm \"{0}\"", r.Name);
            }
            Log.Message();

            if (RealmClass.realm.Start("127.0.0.1", 3724))
            {
                RealmClass.realm.AcceptConnectionThread();
                Log.Message(LogType.NORMAL, "RealmServer listening on {0} port {1}.", "127.0.0.1", 3724);
                Log.Message(LogType.NORMAL, "RealmServer successfully started!");
            }
            else
            {
                Log.Message(LogType.ERROR, "RealmServer couldn't be started: ");
            }

            // Free memory...
            GC.Collect();
            Log.Message(LogType.NORMAL, "Total Memory: {0} Kilobytes", GC.GetTotalMemory(false) / 1024);
            
            // Init Command handlers...
            CommandDefinitions.InitializeRealmCommands();
            CommandManager.InitCommands();
        }
    }
}
