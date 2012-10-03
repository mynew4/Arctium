﻿using Framework.Console;
using Framework.Console.Commands;
using Framework.Database;
using Framework.DBC;
using Framework.Logging;
using Framework.Network.Packets;
using System;
using WorldServer.Game.Managers;
using WorldServer.Network;

namespace WorldServer
{
    class WorldServer
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

            Log.Message(LogType.NORMAL, "Starting Arctium WorldServer...");

            DB.RealmDB.Connect("127.0.0.1", 8000, "arctium", "arctium");
            //DB.WorldDB.Connect("127.0.0.1", 8001, "arctium", "arctium");
            Log.Message();

            DBCLoader.Init();
            DB2Loader.Init();

            Globals.InitializeManager();

            WorldClass.world = new WorldNetwork();

            if (WorldClass.world.Start("127.0.0.1", 8100))
            {
                WorldClass.world.AcceptConnectionThread();
                Log.Message(LogType.NORMAL, "WorldServer listening on {0} port {1}.", "127.0.0.1", 8100);
                Log.Message(LogType.NORMAL, "WorldServer successfully started!");

                HandlerDefinitions.Initialize();
            }
            else
            {
                Log.Message(LogType.ERROR, "Server couldn't be started: ");
            }

            // Free memory...
            GC.Collect();
            Log.Message(LogType.NORMAL, "Total Memory: {0} Kilobytes", GC.GetTotalMemory(false) / 1024);

            // Init Command handlers...
            CommandDefinitions.InitializeWorldCommands();
            CommandManager.InitCommands();
        }
    }
}
