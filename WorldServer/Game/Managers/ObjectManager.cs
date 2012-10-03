using System;
using System.Collections.Generic;
using WorldServer.Game.WorldEntities;
using Framework.Singleton;

namespace WorldServer.Game.Managers
{
    public sealed class ObjectManager : SingletonBase<ObjectManager>
    {
        Dictionary<UInt64, WorldObject> objectList;

        ObjectManager()
        {
            objectList = new Dictionary<UInt64, WorldObject>();
        }

        public void AddObject(WorldObject Object)
        {
        }

        public WorldObject FindObject(UInt64 guid)
        {
            foreach (KeyValuePair<UInt64, WorldObject> kvp in objectList)
                if (kvp.Key == guid)
                    return kvp.Value;

            return null;
        }
    }
}
