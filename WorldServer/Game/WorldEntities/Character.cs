using System;
using System.Linq;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using System.Collections.Generic;
using Framework.Database;
using Framework.Constants;
using Framework.DBC;
using Framework.Network.Packets;
using WorldServer.Game.Managers;
using WorldServer.Network;
using Framework.ObjectDefines;

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
        public List<Spell> Spells = new List<Spell>();

        public Character() { }

        public Character(UInt64 guid, ref WorldClass session) : base((int)PlayerFields.End)
        {
            var result = GetCharacterByGuid(guid);

            Guid           = result.Guid;
            AccountId      = result.AccountId;
            Name           = result.Name;
            Race           = result.Race;
            Class          = result.Class;
            Gender         = result.Gender;
            Skin           = result.Skin;
            Face           = result.Face;
            HairStyle      = result.HairStyle;
            HairColor      = result.HairColor;
            FacialHair     = result.FacialHair;
            Level          = result.Level;
            Zone           = result.Zone;
            Map            = result.Map;
            X              = result.X;
            Y              = result.Y;
            Z              = result.Z;
            O              = result.O;
            GuildGuid      = result.GuildGuid;
            PetDisplayInfo = result.PetDisplayInfo;
            PetLevel       = result.PetLevel;
            PetFamily      = result.PetFamily;
            CharacterFlags = result.CharacterFlags;
            CustomizeFlags = result.CustomizeFlags;

            // Set current session of the character
            Globals.SetSession(ref session);

            SetCharacterFields();
        }

        public static Character GetCharacterByGuid(UInt64 charGuid)
        {
            var character = from Character c in DB.RealmDB.Connection where c.Guid == charGuid select c;

            if (character.Count() == 1)
                return character.First();

            return null;
        }

        public static Character GetCharacterByName(string name)
        {
            var character = from Character c in DB.RealmDB.Connection where c.Name == name select c;

            if (character.Count() == 1)
                return character.First();

            return null;
        }

        public static Character[] GetCharactersByAccount(Account acc)
        {
            var character = from Character c in DB.RealmDB.Connection where c.AccountId == acc.Id select c;

            return character.ToArray();
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
                SetUpdateField<Int32>((int)PlayerFields.Skill + i, 0);

            for (int i = 0; i < 750; i++)
                SetUpdateField<Int32>((int)PlayerFields.QuestLog + i, 0);

            SetUpdateField<Single>((int)PlayerFields.BlockPercentage, 0);

            for (int i = 0; i < 200; i++)
                SetUpdateField<UInt32>((int)PlayerFields.ExploredZones + i, 0);
        }
    }
}
