using Framework.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldServer.Game.WorldEntities;

namespace WorldServer.Game.ObjectStores
{
    public class CharacterStore : SingletonBase<CharacterStore>
    {
        public List<Character> Characters;

        CharacterStore()
        {
            Characters = new List<Character>();
        }
    }
}
