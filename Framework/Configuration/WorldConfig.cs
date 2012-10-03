using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Configuration
{
    public static class WorldConfig
    {
        static Config config = new Config("./Configs/WorldServer.conf");

        public static string CharDBHost = config.Read("CharDB.Host", "");
        public static int CharDBPort = config.Read("CharDB.Port", 3306);
        public static string CharDBUser = config.Read("CharDB.User", "");
        public static string CharDBPassword = config.Read("CharDB.Password", "");
        public static string CharDBDataBase = config.Read("CharDB.Database", "");

        public static string WorldDBHost = config.Read("WorldDB.Host", "");
        public static int WorldDBPort = config.Read("WorldDB.Port", 3306);
        public static string WorldDBUser = config.Read("WorldDB.User", "");
        public static string WorldDBPassword = config.Read("WorldDB.Password", "");
        public static string WorldDBDataBase = config.Read("WorldDB.Database", "");

        public static uint RealmId = config.Read<uint>("RealmId", 1);

        public static string DataPath = config.Read("DataPath", "./Data/");
    }
}
