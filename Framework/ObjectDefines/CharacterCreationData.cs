using Db4objects.Db4o.Linq;
using Framework.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.ObjectDefines
{
    public class CharacterCreationData
    {
        public Byte Race { get; set; }
        public Byte Class { get; set; }
        public UInt32 Map { get; set; }
        public UInt32 Zone { get; set; }
        public Single X { get; set; }
        public Single Y { get; set; }
        public Single Z { get; set; }
        public Single O { get; set; }
        public List<Spell> Spells = new List<Spell>();

        public static CharacterCreationData GetData(byte race, byte pClass)
        {
            var charData = from CharacterCreationData data in DB.RealmDB.Connection where data.Race.Equals(race) && data.Class.Equals(pClass) select data;
            if (charData.Count() > 0)
                return charData.First();

            return null;
        }
    }
}
