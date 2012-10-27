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

using System;
using System.Collections;
using System.Reflection;

namespace Framework.Singleton
{
    public static class Singleton
    {
        static Hashtable ObjectDictionary = new Hashtable();
        static Object Sync = new Object();

        public static T GetInstance<T>() where T : class
        {
            lock (Sync)
            {
                if (ObjectDictionary.ContainsKey(typeof(T).GUID))
                    return (T)ObjectDictionary[typeof(T).GUID];
            }

            // Get info from called constructor
            ConstructorInfo constructorInfo = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            T instance = (T)constructorInfo.Invoke(new object[] { });

            ObjectDictionary.Add(typeof(T).GUID, instance);

            return (T)ObjectDictionary[typeof(T).GUID];
        }
    }
}
