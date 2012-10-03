using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldServer.Network;
using WorldServer.Game.WorldEntities;
using WorldServer.Game.ObjectStores;

namespace WorldServer.Game.Managers
{
    public class Globals
    {
        public static CharacterStore CharacterMgr;
        public static SpellManager SpellMgr;
        public static WorldManager WorldMgr;

        public static WorldClass GetSession() { return WorldMgr.Session; }
        public static void SetSession(ref WorldClass session) { WorldMgr.Session = session; }

        public static Character GetCharacter() { return WorldMgr.Session.Character; }

        public static void InitializeManager()
        {
            CharacterMgr = CharacterStore.GetInstance();
            SpellMgr = SpellManager.GetInstance();
            WorldMgr = WorldManager.GetInstance();
        }
    }
}
