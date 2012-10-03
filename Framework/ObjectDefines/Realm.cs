using Db4objects.Db4o.Linq;
using Framework.Constants;
using Framework.Database;
using System.Collections.Generic;
using System.Linq;

namespace Framework.ObjectDefines
{
    public class Realm
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public uint Port { get; set; }
        public Dictionary<Class, Expansion> RealmClasses;
        public Dictionary<Race, Expansion> RealmRaces;

        public static Realm GetRealmById(uint realmId)
        {
            var realms = from Realm a in DB.RealmDB.Connection where a.Id == realmId select a;

            if (realms.Count() == 1)
                return realms.First();

            return null;
        }

        public static Realm GetRealmByName(string name)
        {
            var realms = from Realm a in DB.RealmDB.Connection where a.Name == name select a;

            if (realms.Count() == 1)
                return realms.First();

            return null;
        }

        public static Dictionary<Class, Expansion> GetClassesByRealmId(uint realmId)
        {
            var classes = from Realm c in DB.RealmDB.Connection where c.Id == realmId select c;

            if (classes.Count() == 1)
                return classes.First().RealmClasses;

            return null;
        }

        public static Dictionary<Race, Expansion> GetRacesByRealmId(uint realmId)
        {
            var races = from Realm c in DB.RealmDB.Connection where c.Id == realmId select c;

            if (races.Count() == 1)
                return races.First().RealmRaces;

            return null;
        }
    }
}
