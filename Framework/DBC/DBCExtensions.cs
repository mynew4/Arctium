using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DBC
{
    public static class DBCExtensions
    {
        public static T ReadStruct<T>(this BinaryReader reader, string fmt) where T : struct
        {
            byte[] rawData = new byte[Marshal.SizeOf(typeof(T))];

            int index = 0;
            foreach (char c in fmt)
            {
                if (c.ToString().Equals("x"))
                    reader.BaseStream.Position += 4;
                else
                {
                    reader.Read(rawData, index, 4);
                    index += 4;
                }
            }

            GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            T returnObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));

            handle.Free();

            return returnObject;
        }

        public static T ReadHeader<T>(this BinaryReader reader) where T : struct
        {
            byte[] rawData = reader.ReadBytes(Marshal.SizeOf(typeof(T)));

            GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            T returnObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));

            handle.Free();

            return returnObject;
        }

        public static string ReadCString(this BinaryReader reader)
        {
            byte num;
            List<byte> temp = new List<byte>();

            while ((num = reader.ReadByte()) != 0)
            {
                temp.Add(num);
            }

            return Encoding.UTF8.GetString(temp.ToArray());
        }

        public static T LookupByKey<T>(this Dictionary<uint, T> dictionary, uint key)
        {
            T value;
            dictionary.TryGetValue(key, out value);
            return value;
        }

        public static int GetFMTCount(this string fmt)
        {
            int count = 0;
            foreach (char c in fmt)
            {
                if (!c.Equals('x'))
                    count += 1;
            }
            return count * 4;
        }

    }
}
