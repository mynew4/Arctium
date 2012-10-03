using Framework.Constants;
using Framework.Database;
using Framework.Logging;
using Framework.ObjectDefines;
using System;
using System.Collections.Generic;

namespace Framework.Console.Commands
{
    public class RealmsCommands : CommandParser
    {
        public static void CreateRealm(string[] args)
        {
            string name = Read<string>(args, 0);
            string ip = Read<string>(args, 1);
            uint port = Read<uint>(args, 2);

            if (name == null || ip == null)
                return;

            Realm realm = new Realm();
            realm.RealmClasses = new Dictionary<Class, Expansion>();
            realm.RealmRaces = new Dictionary<Race, Expansion>();

            realm.Name = name;
            realm.IP = ip;
            realm.Port = port;

            // Add default realm class/expansion data
            realm.RealmClasses.Add(Class.Warrior, Expansion.Classic);
            realm.RealmClasses.Add(Class.Paladin, Expansion.Classic);
            realm.RealmClasses.Add(Class.Hunter, Expansion.Classic);
            realm.RealmClasses.Add(Class.Rogue, Expansion.Classic);
            realm.RealmClasses.Add(Class.Priest, Expansion.Classic);
            realm.RealmClasses.Add(Class.Deathknight, Expansion.LichKing);
            realm.RealmClasses.Add(Class.Shaman, Expansion.Classic);
            realm.RealmClasses.Add(Class.Mage, Expansion.Classic);
            realm.RealmClasses.Add(Class.Warlock, Expansion.Classic);
            realm.RealmClasses.Add(Class.Monk, Expansion.Pandaria);
            realm.RealmClasses.Add(Class.Druid, Expansion.Classic);

            // Add default realm race/expansion data
            realm.RealmRaces.Add(Race.Human, Expansion.Classic);
            realm.RealmRaces.Add(Race.Orc, Expansion.Classic);
            realm.RealmRaces.Add(Race.Dwarf, Expansion.Classic);
            realm.RealmRaces.Add(Race.NightElf, Expansion.Classic);
            realm.RealmRaces.Add(Race.Scourge, Expansion.Classic);
            realm.RealmRaces.Add(Race.Tauren, Expansion.Classic);
            realm.RealmRaces.Add(Race.Gnome, Expansion.Classic);
            realm.RealmRaces.Add(Race.Troll, Expansion.Classic);
            realm.RealmRaces.Add(Race.Goblin, Expansion.Cataclysm);
            realm.RealmRaces.Add(Race.BloodElf, Expansion.BurningCrusade);
            realm.RealmRaces.Add(Race.Draenei, Expansion.BurningCrusade);
            realm.RealmRaces.Add(Race.Worgen, Expansion.Cataclysm);
            realm.RealmRaces.Add(Race.PandarenNeutral, Expansion.Pandaria);
            realm.RealmRaces.Add(Race.PandarenAlliance, Expansion.Pandaria);
            realm.RealmRaces.Add(Race.PandarenHorde, Expansion.Pandaria);

            var result = Realm.GetRealmByName(name);
            realm.Id = (uint)DB.RealmDB.RowCount + 1;

            if (result == null)
            {
                DB.RealmDB.Save(realm);
                Log.Message(LogType.NORMAL, "Realm {0} successfully created", name);
            }
            else
                Log.Message(LogType.ERROR, "Realm {0} already in database", name);
        }
    }
}
