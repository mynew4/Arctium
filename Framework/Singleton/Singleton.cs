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
