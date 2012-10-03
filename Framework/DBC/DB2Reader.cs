using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using Framework.Configuration;
using Framework.Logging;

namespace Framework.DBC
{
    static class DB2Reader
    {
        public static Dictionary<uint, T> ReadDB2<T>(Dictionary<uint, string> strDict, string _fmt, string FileName) where T : struct
        {
            Dictionary<uint, T> dict = new Dictionary<uint, T>();
            
            string path = WorldConfig.DataPath + "/dbc/" + FileName;
            try
            {
                using (BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read), Encoding.UTF8))
                {
                    Db2Header header = reader.ReadHeader<Db2Header>();
                    int size = Marshal.SizeOf(typeof(T));

                    if (!header.IsDB2)
                    {
                        Log.Message(Logging.LogType.ERROR, "{0} is not DB2 File", FileName);
                        return null;
                    }

                    if (header.RecordSize != _fmt.Length * 4)
                    {
                        Log.Message(Logging.LogType.ERROR, "Size of '{0}' setted by format string ({1}) not equal size of C# structure ({2}).", FileName, _fmt.Length * 4, header.RecordSize);
                        return null;
                    }

                    int structsize = Marshal.SizeOf(typeof(T));
                    if (structsize != _fmt.GetFMTCount())
                    {
                        Log.Message(Logging.LogType.ERROR, "Size of '{0}' setted by format string ({1}) not equal size of C# Structure ({2}).", FileName, _fmt.GetFMTCount(), structsize);
                        return null;
                    }

                    byte[] index = new byte[header.RecordsCount];
                    // WDB2 specific fields
                    uint tableHash = reader.ReadUInt32();   // new field in WDB2
                    uint build = reader.ReadUInt32();       // new field in WDB2
                    uint unk1 = reader.ReadUInt32();        // new field in WDB2

                    if (build > 12880) // new extended header
                    {
                        int MinId = reader.ReadInt32();     // new field in WDB2
                        int MaxId = reader.ReadInt32();     // new field in WDB2
                        int locale = reader.ReadInt32();    // new field in WDB2
                        int unk5 = reader.ReadInt32();      // new field in WDB2

                        if (MaxId != 0)
                        {
                            int diff = MaxId - MinId + 1;   // blizzard is weird people...
                            reader.Read(index, 0, diff * 4);     // an index for rows
                            reader.ReadBytes(diff * 2);     // a memory allocation bank
                        }
                    }

                    for (int r = 0; r < header.RecordsCount; ++r)
                    {
                        uint key = reader.ReadUInt32();
                        reader.BaseStream.Position -= 4;

                        T T_entry = reader.ReadStruct<T>(_fmt);

                        dict.Add(key, T_entry);
                    }

                    if (strDict != null)
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            var offset = (uint)(reader.BaseStream.Position - header.StartStringPosition);
                            var str = reader.ReadCString();
                            strDict.Add(offset, str);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Logging.Log.Message(Logging.LogType.ERROR, "Cant Find File {0}.db2", FileName);
                return null;
            }
            finally
            {
                DB2Storage.DB2FileCount += 1;
            }

            return dict;
        }
    }
}
