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

using Framework.Constants;
using Framework.Database;
using Framework.DBC;
using System;
using System.Collections.Generic;
using WorldServer.Game.Managers;

namespace WorldServer.Game.WorldEntities
{
    public class Character : WorldObject
    {
        public UInt32 AccountId;
        public UInt64 Guid;
        public String Name;
        public Byte Race;
        public Byte Class;
        public Byte Gender;
        public Byte Skin;
        public Byte Face;
        public Byte HairStyle;
        public Byte HairColor;
        public Byte FacialHair;
        public Byte Level;
        public UInt32 Zone;
        public UInt32 Map;
        public Single X;
        public Single Y;
        public Single Z;
        public Single O;
        public UInt64 GuildGuid;
        public UInt32 PetDisplayInfo;
        public UInt32 PetLevel;
        public UInt32 PetFamily;
        public UInt32 CharacterFlags;
        public UInt32 CustomizeFlags;

        public List<Skill> Skills = new List<Skill>();
        public List<PlayerSpell> SpellList = new List<PlayerSpell>();

        public Character(UInt64 guid) : base((int)PlayerFields.End)
        {
            SQLResult result = DB.Characters.Select("SELECT * FROM characters WHERE guid = {0}", guid);

            Guid           = result.Read<UInt64>(0, "Guid");
            AccountId      = result.Read<UInt32>(0, "AccountId");
            Name           = result.Read<String>(0, "Name");
            Race           = result.Read<Byte>(0, "Race");
            Class          = result.Read<Byte>(0, "Class");
            Gender         = result.Read<Byte>(0, "Gender");
            Skin           = result.Read<Byte>(0, "Skin");
            Face           = result.Read<Byte>(0, "Face");
            HairStyle      = result.Read<Byte>(0, "HairStyle");
            HairColor      = result.Read<Byte>(0, "HairColor");
            FacialHair     = result.Read<Byte>(0, "FacialHair");
            Level          = result.Read<Byte>(0, "Level");
            Zone           = result.Read<UInt32>(0, "Zone");
            Map            = result.Read<UInt32>(0, "Map");
            X              = result.Read<Single>(0, "X");
            Y              = result.Read<Single>(0, "Y");
            Z              = result.Read<Single>(0, "Z");
            O              = result.Read<Single>(0, "O");
            GuildGuid      = result.Read<UInt64>(0, "GuildGuid");
            PetDisplayInfo = result.Read<UInt32>(0, "PetDisplayId");
            PetLevel       = result.Read<UInt32>(0, "PetLevel");
            PetFamily      = result.Read<UInt32>(0, "PetFamily");
            CharacterFlags = result.Read<UInt32>(0, "CharacterFlags");
            CustomizeFlags = result.Read<UInt32>(0, "CustomizeFlags");

            Globals.SpellMgr.LoadSpells(this);
            Globals.SkillMgr.LoadSkills(this);

            SetCharacterFields();
        }

        public void SetCharacterFields()
        {
            // ObjectFields
            SetUpdateField<UInt64>((int)ObjectFields.Guid, Guid);
            SetUpdateField<UInt64>((int)ObjectFields.Data, 0);
            SetUpdateField<UInt64>((int)ObjectFields.Entry, 0);
            SetUpdateField<Int32>((int)ObjectFields.Type, 0x19);
            SetUpdateField<Single>((int)ObjectFields.Scale, 1.0f);

            // UnitFields
            SetUpdateField<UInt64>((int)UnitFields.Charm, 0);
            SetUpdateField<UInt64>((int)UnitFields.Summon, 0);
            SetUpdateField<UInt64>((int)UnitFields.Critter, 0);
            SetUpdateField<UInt64>((int)UnitFields.CharmedBy, 0);
            SetUpdateField<UInt64>((int)UnitFields.SummonedBy, 0);
            SetUpdateField<UInt64>((int)UnitFields.CreatedBy, 0);
            SetUpdateField<UInt64>((int)UnitFields.Target, 0);
            SetUpdateField<UInt64>((int)UnitFields.ChannelObject, 0);

            SetUpdateField<Int32>((int)UnitFields.Health, 123);

            for (int i = 0; i < 5; i++)
                SetUpdateField<Int32>((int)UnitFields.Power + i, 0);

            SetUpdateField<Int32>((int)UnitFields.MaxHealth, 123);

            for (int i = 0; i < 5; i++)
                SetUpdateField<Int32>((int)UnitFields.MaxPower + i, 0);

            SetUpdateField<Int32>((int)UnitFields.PowerRegenFlatModifier, 0);
            SetUpdateField<Int32>((int)UnitFields.PowerRegenInterruptedFlatModifier, 0);
            SetUpdateField<Int32>((int)UnitFields.BaseHealth, 0);
            SetUpdateField<Int32>((int)UnitFields.BaseMana, 0);
            SetUpdateField<Int32>((int)UnitFields.Level, Level);
            SetUpdateField<Int32>((int)UnitFields.FactionTemplate, (int)DBCStorage.RaceStorage[Race].FactionID);
            SetUpdateField<Int32>((int)UnitFields.Flags, 0);
            SetUpdateField<Int32>((int)UnitFields.Flags2, 0);

            for (int i = 0; i < 5; i++)
            {
                SetUpdateField<Int32>((int)UnitFields.Stats + i, 0);
                SetUpdateField<Int32>((int)UnitFields.StatPosBuff + i, 0);
                SetUpdateField<Int32>((int)UnitFields.StatNegBuff + i, 0);
            }

            SetUpdateField<Byte>((int)UnitFields.DisplayPower, Race, 0);
            SetUpdateField<Byte>((int)UnitFields.DisplayPower, Class, 1);
            SetUpdateField<Byte>((int)UnitFields.DisplayPower, Gender, 2);
            SetUpdateField<Byte>((int)UnitFields.DisplayPower, 0, 3);

            uint displayId = Gender == 0 ? DBCStorage.RaceStorage[Race].model_m : DBCStorage.RaceStorage[Race].model_f;
            SetUpdateField<Int32>((int)UnitFields.DisplayID, (int)displayId);
            SetUpdateField<Int32>((int)UnitFields.NativeDisplayID, (int)displayId);
            SetUpdateField<Int32>((int)UnitFields.MountDisplayID, 0);
            SetUpdateField<Int32>((int)UnitFields.DynamicFlags, 0);

            SetUpdateField<Single>((int)UnitFields.BoundingRadius, 0.389F);
            SetUpdateField<Single>((int)UnitFields.CombatReach, 1.5F);
            SetUpdateField<Single>((int)UnitFields.MinDamage, 0);
            SetUpdateField<Single>((int)UnitFields.MaxDamage, 0);
            SetUpdateField<Single>((int)UnitFields.ModCastingSpeed, 1);
            SetUpdateField<Int32>((int)UnitFields.AttackPower, 0);
            SetUpdateField<Int32>((int)UnitFields.RangedAttackPower, 0);

            for (int i = 0; i < 7; i++)
            {
                SetUpdateField<Int32>((int)UnitFields.Resistances + i, 0);
                SetUpdateField<Int32>((int)UnitFields.ResistanceBuffModsPositive + i, 0);
                SetUpdateField<Int32>((int)UnitFields.ResistanceBuffModsNegative + i, 0);
            }

            SetUpdateField<Byte>((int)UnitFields.AnimTier, 0, 0);
            SetUpdateField<Byte>((int)UnitFields.AnimTier, 0, 1);
            SetUpdateField<Byte>((int)UnitFields.AnimTier, 0, 2);
            SetUpdateField<Byte>((int)UnitFields.AnimTier, 0, 3);

            SetUpdateField<Int16>((int)UnitFields.RangedAttackRoundBaseTime, 0);
            SetUpdateField<Int16>((int)UnitFields.RangedAttackRoundBaseTime, 0);
            SetUpdateField<Single>((int)UnitFields.MinOffHandDamage, 0);
            SetUpdateField<Single>((int)UnitFields.MaxOffHandDamage, 0);
            SetUpdateField<Int32>((int)UnitFields.AttackPowerModPos, 0);
            SetUpdateField<Int32>((int)UnitFields.RangedAttackPowerModPos, 0);
            SetUpdateField<Single>((int)UnitFields.MinRangedDamage, 0);
            SetUpdateField<Single>((int)UnitFields.MaxRangedDamage, 0);
            SetUpdateField<Single>((int)UnitFields.AttackPowerMultiplier, 0);
            SetUpdateField<Single>((int)UnitFields.RangedAttackPowerMultiplier, 0);
            SetUpdateField<Single>((int)UnitFields.MaxHealthModifier, 1);
            
            // PlayerFields
            SetUpdateField<Int32>((int)PlayerFields.MaxLevel, 90);
            SetUpdateField<Byte>((int)PlayerFields.HairColorID, Skin, 0);
            SetUpdateField<Byte>((int)PlayerFields.HairColorID, Face, 1);
            SetUpdateField<Byte>((int)PlayerFields.HairColorID, HairStyle, 2);
            SetUpdateField<Byte>((int)PlayerFields.HairColorID, HairColor, 3);
            SetUpdateField<Byte>((int)PlayerFields.RestState, FacialHair, 0);
            SetUpdateField<Byte>((int)PlayerFields.RestState, 0, 1);
            SetUpdateField<Byte>((int)PlayerFields.RestState, 0, 2);
            SetUpdateField<Byte>((int)PlayerFields.RestState, 2, 3);
            SetUpdateField<Byte>((int)PlayerFields.ArenaFaction, Gender, 0);
            SetUpdateField<Byte>((int)PlayerFields.ArenaFaction, 0, 1);
            SetUpdateField<Byte>((int)PlayerFields.ArenaFaction, 0, 2);
            SetUpdateField<Byte>((int)PlayerFields.ArenaFaction, 0, 3);
            SetUpdateField<Int32>((int)PlayerFields.WatchedFactionIndex, -1);
            SetUpdateField<Int32>((int)PlayerFields.XP, 0);
            SetUpdateField<Int32>((int)PlayerFields.NextLevelXP, 400);
            SetUpdateField<Int32>((int)PlayerFields.PlayerFlags, 0);
            SetUpdateField<Int32>((int)PlayerFields.CharacterPoints, 0);
            SetUpdateField<Int32>((int)PlayerFields.GuildRankID, 0);
            SetUpdateField<Single>((int)PlayerFields.CritPercentage, 0);
            SetUpdateField<Single>((int)PlayerFields.RangedCritPercentage, 0);
            SetUpdateField<Int32>((int)PlayerFields.ModHealingDonePos, 0);

            for (int i = 0; i < 7; i++)
            {
                SetUpdateField<Single>((int)PlayerFields.SpellCritPercentage + i, 0);
                SetUpdateField<Int32>((int)PlayerFields.ModDamageDonePos + i, 0);
                SetUpdateField<Int32>((int)PlayerFields.ModDamageDoneNeg + i, 0);
                SetUpdateField<Single>((int)PlayerFields.ModDamageDonePercent + i, 0);
            }

            SetUpdateField<UInt64>((int)PlayerFields.Coinage, 0);

            for (int i = 0; i < 448; i++)
                if (i < Skills.Count)
                    SetUpdateField<UInt32>((int)PlayerFields.Skill + i, Skills[i].Id);
                else
                    SetUpdateField<UInt32>((int)PlayerFields.Skill + i, 0);

            for (int i = 0; i < 750; i++)
                SetUpdateField<Int32>((int)PlayerFields.QuestLog + i, 0);

            SetUpdateField<UInt32>((int)PlayerFields.HomePlayerRealm, 1);
            SetUpdateField<Single>((int)PlayerFields.BlockPercentage, 0);

            for (int i = 0; i < 200; i++)
                SetUpdateField<UInt32>((int)PlayerFields.ExploredZones + i, 0);
        }
    }
}
