﻿using System;
using Framework.Configuration;
using Framework.Console;
using Framework.Console.Commands;
using Framework.Database;
using Framework.Logging;
using Framework.Network.Packets;
using WorldServer.Network;
using Framework.DBC;
using WorldServer.Game.Managers;

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

            DB.Characters.Init(WorldConfig.CharDBHost, WorldConfig.CharDBUser, WorldConfig.CharDBPassword, WorldConfig.CharDBDataBase, WorldConfig.CharDBPort);
            DB.Realms.Init(RealmConfig.RealmDBHost, RealmConfig.RealmDBUser, RealmConfig.RealmDBPassword, RealmConfig.RealmDBDataBase, RealmConfig.RealmDBPort);
            DB.World.Init(WorldConfig.WorldDBHost, WorldConfig.WorldDBUser, WorldConfig.WorldDBPassword, WorldConfig.WorldDBDataBase, WorldConfig.WorldDBPort);
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

                PacketManager.DefineOpcodeHandler();
            }
            else
            {
                Log.Message(LogType.ERROR, "Server couldn't be started: ");
            }

            // Free memory...
            GC.Collect();
            Log.Message(LogType.NORMAL, "Total Memory: {0} Kilobytes", GC.GetTotalMemory(false) / 1024);

            // Init Command handlers...
            CommandDefinitions.Initialize();
            CommandManager.InitCommands();
        }
    }
}
