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
    public struct DbcHeader
    {
        public int Signature;
        public int RecordsCount;
        public int FieldsCount;
        public int RecordSize;
        public int StringTableSize;

        public bool IsDBC
        {
            get { return Signature == 0x43424457; }
        }

        public long DataSize
        {
            get { return (long)(RecordsCount * RecordSize); }
        }

        public long StartStringPosition
        {
            get { return DataSize + (long)Marshal.SizeOf(typeof(DbcHeader)); }
        }
    };


    public struct ChrClasses
    {
        public uint ClassID;                                        // 0        m_ID
        public uint powerType;                                      // 1        m_DisplayPower
        // 2        m_petNameToken
        public uint _name;                                         // 3        m_name_lang
        //char*       nameFemale;                               // 4        m_name_female_lang
        //char*       nameNeutralGender;                        // 5        m_name_male_lang
        //char*       capitalizedName                           // 6,       m_filename
        public uint spellfamily;                                    // 7        m_spellClassSet
        //uint32 flags2;                                        // 8        m_flags (0x08 HasRelicSlot)
        public uint CinematicSequence;                              // 9        m_cinematicSequenceID
        public uint expansion;                                      // 10       m_required_expansion
        //uint32                                                // 11
        //uint32                                                // 12
        //uint32                                                // 13

        /// <summary>
        /// Return current Race Name
        /// </summary>
        public string ClassName
        {
            get { return DBCStorage.ClassStrings.LookupByKey(_name); }
        }
    };

    public struct ChrRaces
    {
        public uint RaceID;                                     // 0
        // 1 unused
        public uint FactionID;                                  // 2 faction template id
        // 3 unused
        public uint model_m;                                    // 4
        public uint model_f;                                    // 5
        // 6 unused
        public uint TeamID;                                     // 7 (7-Alliance 1-Horde)
        // 8-11 unused
        public uint CinematicSequence;                          // 12 id from CinematicSequences.dbc
        // 13 unused
        public uint _name;                                      // 14
        // 17
        // 16 
        // 17-18    m_facialHairCustomization[2]
        // 19       m_hairCustomization
        //uint32                                                // 20 (23 for worgens)
        //uint32                                                // 21 4.0.0
        //uint32                                                // 22 4.0.0

        /// <summary>
        /// Return current Race Name
        /// </summary>
        public string RaceName
        {
            get { return DBCStorage.RaceStrings.LookupByKey(_name); }
        }
    };

    public struct CharStartOutfit
    {
        public uint Mask;      // Race, Class, Gender, ?

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public uint[] ItemId;
    }

    public struct NameGen
    {
        public uint Id;
        public uint _name;
        public uint Race;
        public uint Gender;

        public string Name
        {
            get { return DBCStorage.NameGenStrings.LookupByKey(_name); }
        }
    }
}
