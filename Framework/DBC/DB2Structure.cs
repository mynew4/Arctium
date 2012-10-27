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
