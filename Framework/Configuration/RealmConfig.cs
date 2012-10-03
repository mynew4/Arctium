using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Configuration
{
    public static class RealmConfig
    {
        static Config config = new Config("./Configs/RealmServer.conf");

        public static string RealmDBHost = config.Read("RealmDB.Host", "");
        public static int RealmDBPort = config.Read("RealmDB.Port", 3306);
        public static string RealmDBUser = config.Read("RealmDB.User", "");
        public static string RealmDBPassword = config.Read("RealmDB.Password", "");
        public static string RealmDBDataBase = config.Read("RealmDB.Database", "");
    }
}
