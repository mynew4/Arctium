/*
 * Copyright (C) 2012 Arctium <http://>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Framework.Singleton;
using System;
using System.Collections.Generic;
using WorldServer.Game.WorldEntities;

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
