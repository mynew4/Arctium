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
        public static SkillManager SkillMgr;
        public static SpellManager SpellMgr;
        public static WorldManager WorldMgr;

        public static void InitializeManager()
        {
            CharacterMgr = CharacterStore.GetInstance();
            SkillMgr = SkillManager.GetInstance();
            SpellMgr = SpellManager.GetInstance();
            WorldMgr = WorldManager.GetInstance();
        }
    }
}
