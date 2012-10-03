using Framework.Constants;
using Framework.Database;
using Framework.DBC;
using Framework.Logging;
using Framework.Network.Packets;
using Framework.ObjectDefines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldServer.Game.Managers;
using WorldServer.Game.WorldEntities;
using WorldServer.Network;

namespace WorldServer.Game.PacketHandler
{
    public class CharacterHandler : Globals
    {
        public static void HandleCharacterEnum(ref PacketReader packet, ref WorldClass session)
        {
            var result = Character.GetCharactersByAccount(session.Account);

            PacketWriter enumCharacters = new PacketWriter(JAMCMessage.EnumCharactersResult);
            BitPack BitPack = new BitPack(enumCharacters);

            BitPack.Write(0, 23);
            BitPack.Write(1);
            BitPack.Write(result.Length, 17);

            if (result.Length != 0)
            {
                foreach (Character c in result)
                {
                    string name = c.Name;
                    BitPack.Guid = c.Guid;
                    BitPack.GuildGuid = c.GuildGuid;

                    BitPack.WriteGuidMask(4);
                    BitPack.WriteGuildGuidMask(7, 3, 0, 1);
                    BitPack.Write(0);
                    BitPack.WriteGuidMask(6);
                    BitPack.WriteGuildGuidMask(6);
                    BitPack.WriteGuidMask(1);
                    BitPack.Write((uint)Encoding.ASCII.GetBytes(name).Length, 7);
                    BitPack.WriteGuildGuidMask(2);
                    BitPack.WriteGuidMask(2, 0, 3, 5);
                    BitPack.WriteGuildGuidMask(4);
                    BitPack.WriteGuidMask(7);
                    BitPack.WriteGuildGuidMask(5);
                }

                BitPack.Flush();

                foreach (Character c in result)
                {
                    string name = c.Name;
                    BitPack.Guid = c.Guid;
                    BitPack.GuildGuid = c.GuildGuid;

                    // Not implanted
                    for (int j = 0; j < 23; j++)
                    {
                        enumCharacters.WriteUInt32(0);
                        enumCharacters.WriteUInt32(0);
                        enumCharacters.WriteUInt8(0);
                    }

                    enumCharacters.WriteUInt8(c.HairStyle);
                    enumCharacters.WriteUInt8(c.Race);

                    BitPack.WriteGuidBytes(0);
                    BitPack.WriteGuildGuidBytes(4);

                    enumCharacters.WriteUInt8(c.FacialHair);
                    enumCharacters.WriteUInt8(c.HairColor);
                    enumCharacters.WriteFloat(c.Z);

                    BitPack.WriteGuildGuidBytes(6);
                    BitPack.WriteGuidBytes(7);
                    BitPack.WriteGuildGuidBytes(0);

                    enumCharacters.WriteUInt32(c.CharacterFlags);
                    enumCharacters.WriteUInt32(c.Zone);

                    BitPack.WriteGuidBytes(5, 6);

                    enumCharacters.WriteUInt32(c.CustomizeFlags);
                    enumCharacters.WriteUInt32(c.Map);

                    BitPack.WriteGuidBytes(1);

                    enumCharacters.WriteUInt32(c.PetDisplayInfo);

                    BitPack.WriteGuildGuidBytes(1);

                    enumCharacters.WriteUInt8(c.Face);
                    enumCharacters.WriteUInt32(c.PetFamily);
                    enumCharacters.WriteUInt8(c.Skin);

                    BitPack.WriteGuidBytes(4);
                    BitPack.WriteGuildGuidBytes(5);

                    enumCharacters.WriteBytes(Encoding.ASCII.GetBytes(name));
                    enumCharacters.WriteUInt32(c.PetLevel);
                    enumCharacters.WriteUInt8(c.Gender);
                    enumCharacters.WriteFloat(c.X);
                    enumCharacters.WriteUInt8(c.Class);
                    enumCharacters.WriteUInt8(0);
                    enumCharacters.WriteFloat(c.Y);

                    BitPack.WriteGuildGuidBytes(3, 7, 2);

                    enumCharacters.WriteUInt8(c.Level);

                    BitPack.WriteGuidBytes(2, 3);
                }
            }
            else
            {
                BitPack.Flush();
            };

            session.Send(enumCharacters);
        }

        public static void HandleRequestCharCreate(ref PacketReader packet, ref WorldClass session)
        {
            BitUnpack BitUnpack = new BitUnpack(packet);

            byte gender = packet.ReadByte();
            byte hairColor = packet.ReadByte();
            packet.ReadByte();                      // Always 0
            byte race = packet.ReadByte();
            byte pClass = packet.ReadByte();
            byte face = packet.ReadByte();
            byte facialHair = packet.ReadByte();
            byte skin = packet.ReadByte();
            byte hairStyle = packet.ReadByte();

            uint nameLength = BitUnpack.GetNameLength<uint>(7);
            string name = packet.ReadString(nameLength);

            var result = Character.GetCharacterByName(name);
            PacketWriter writer = new PacketWriter(LegacyMessage.ResponseCharacterCreate);

            if (result != null)
            {
                // Name already in use
                writer.WriteUInt8(0x32);
                session.Send(writer);
                return;
            }

            var charData = CharacterCreationData.GetData(race, pClass);
            if (charData == null)
            {
                writer.WriteUInt8(0x31);
                session.Send(writer);
                return;
            }

            Character newChar = new Character();
            newChar.Name = name;
            newChar.AccountId = (uint)session.Account.Id;
            newChar.Race = race;
            newChar.Class = pClass;
            newChar.Gender = gender;
            newChar.Level = 1;
            newChar.Skin = skin;
            newChar.Zone = charData.Zone;
            newChar.Map = charData.Map;
            newChar.X = charData.X;
            newChar.Y = charData.Y;
            newChar.Z = charData.Z;
            newChar.O = charData.O;
            newChar.Face = face;
            newChar.HairStyle = hairStyle;
            newChar.HairColor = hairColor;
            newChar.FacialHair = facialHair;
            charData.Spells.ForEach(spell => newChar.Spells.Add(spell));

            DB.RealmDB.Save(newChar);

            // Success
            writer.WriteUInt8(0x2F);
            session.Send(writer);
        }

        public static void HandleRequestCharDelete(ref PacketReader packet, ref WorldClass session)
        {
            UInt64 guid = packet.ReadUInt64();

            var character = Character.GetCharacterByGuid(guid);
            if (character != null)
            {
                PacketWriter writer = new PacketWriter(LegacyMessage.ResponseCharacterDelete);
                writer.WriteUInt8(0x47);
                session.Send(writer);

                DB.RealmDB.Delete(character);
            }
        }

        public static void HandleRequestRandomCharacterName(ref PacketReader packet, ref WorldClass session)
        {
            byte gender = packet.ReadByte();
            byte race = packet.ReadByte();

            List<string> names = DBCStorage.NameGenStorage.Where(n => n.Value.Race == race && n.Value.Gender == gender).Select(n => n.Value.Name).ToList();
            Random rand = new Random(Environment.TickCount);

            string NewName;
            Character result;
            do
            {
                NewName = names[rand.Next(names.Count)];
                result = Character.GetCharacterByName(NewName);
            }
            while (result != null);

            PacketWriter writer = new PacketWriter(JAMCMessage.GenerateRandomCharacterNameResult);

            writer.WriteUInt8((byte)(0x80 + NewName.Length));
            writer.WriteString(NewName);
            session.Send(writer);
        }

        public static void HandlePlayerLogin(ref PacketReader packet, ref WorldClass session)
        {
            byte[] guidMask = { 6, 3, 0, 5, 7, 2, 1, 4 };
            byte[] guidBytes = { 1, 0, 3, 2, 4, 7, 5, 6 };

            BitUnpack GuidUnpacker = new BitUnpack(packet);

            ulong guid = GuidUnpacker.GetGuid(guidMask, guidBytes);
            Log.Message(LogType.DEBUG, "Character with Guid: {0}, AccountId: {1} tried to enter the world.", guid, session.Account.Id);

            session.Character = new Character(guid, ref session);
            WorldMgr.Session = session;

            WorldMgr.WriteAccountData(AccountDataMasks.CharacterCacheMask, ref session);

            PacketWriter motd = new PacketWriter(LegacyMessage.MessageOfTheDay);
            motd.WriteUInt32(3);

            motd.WriteCString("Arctium MoP test");
            motd.WriteCString("Welcome to our MoP server test.");
            motd.WriteCString("Your development team =)");
            session.Send(motd);

            SpellHandler.SendSendKnownSpells();
            UpdateHandler.HandleUpdateObject(ref packet, ref session);
        }
    }
}
