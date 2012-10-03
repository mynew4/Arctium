using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Framework.DBC
{
    public struct Db2Header
    {
        public int Signature;
        public int RecordsCount;
        public int FieldsCount;
        public int RecordSize;
        public int StringTableSize;

        public bool IsDB2
        {
            get { return Signature == 0x32424457; }
        }

        public long DataSize
        {
            get { return (long)(RecordsCount * RecordSize); }
        }

        public long StartStringPosition
        {
            get { return DataSize + (long)Marshal.SizeOf(typeof(Db2Header)); }
        }
    }

    public struct ItemEntry
    {
        public uint Id;                                             // 0
        public uint Class;                                          // 1
        public uint SubClass;                                       // 2
        public int  Unk0;                                           // 3
        public int  Material;                                       // 4
        public uint DisplayId;                                      // 5
        public uint InventoryType;                                  // 6
        public uint Sheath;                                         // 7
    };

}
