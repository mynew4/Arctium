/*
 * Copyright (C) 2012 Arctium <http://>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Framework.Configuration;
using Framework.Database;
using Framework.Logging;
using Framework.Network.Realm;
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

            DB.Realms.Init(RealmConfig.RealmDBHost, RealmConfig.RealmDBUser, RealmConfig.RealmDBPassword, RealmConfig.RealmDBDataBase, RealmConfig.RealmDBPort);

            RealmClass.realm = new RealmNetwork();

            // Add realms from database.
            Log.Message(LogType.NORMAL, "Updating Realm List..."); 
            Log.Message();
            SQLResult result = DB.Realms.Select("SELECT * FROM realms");
            for (int i = 0; i < result.Count; i++)
            {
                RealmClass.Realms.Add(new Framework.ObjectDefines.Realm()
                {
                    Id = result.Read<uint>(i, "id"),
                    Name = result.Read<string>(i, "name"),
                    IP = result.Read<string>(i, "ip"),
                    Port = result.Read<uint>(i, "port"),
                });

                Log.Message(LogType.NORMAL, "Added Realm \"{0}\"", RealmClass.Realms[i].Name);
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
        }
    }
}
