using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Network.Packets;
using Framework.Constants;
using Framework.DBC;

namespace WorldServer.Game.WorldEntities
{
    public enum PlayerSpellState
    {
        Unchanged = 0,
        Changed = 1,
        New = 2,
        Removed = 3,
        Temporary = 4
    }

    public class PlayerSpell
    {
        public uint SpellId;
        public PlayerSpellState State;
        public bool Active;
        public bool Dependent;
        public bool Disabled;
    }

    public static class SpellMethods
    {
        public static PlayerSpell FindPlayerSpell(this List<PlayerSpell> SpellList, uint spellId)
        {
            return SpellList.Find(p => p.SpellId == spellId);
        }
    }
}
