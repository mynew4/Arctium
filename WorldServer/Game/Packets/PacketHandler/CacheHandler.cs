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
using Framework.Network.Packets;
using WorldServer.Network;
using WorldServer.Game.WorldEntities;
using Framework.Configuration;
using Framework.Database;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class CacheHandler
    {
        [Opcode(ClientMessage.NameCache, "16135")]
        public static void HandleNameCache(ref PacketReader packet, ref WorldClass session)
        {
            Character pChar = session.Character;

            ulong guid = packet.ReadUInt64();
            uint realmId = packet.ReadUInt32();

            PacketWriter nameCache = new PacketWriter(LegacyMessage.NameCache);

            nameCache.WriteGuid(guid);
            nameCache.WriteUInt8(0);
            nameCache.WriteCString(pChar.Name);
            nameCache.WriteUInt32(realmId);
            nameCache.WriteUInt8(pChar.Race);
            nameCache.WriteUInt8(pChar.Gender);
            nameCache.WriteUInt8(pChar.Class);
            nameCache.WriteUInt8(0);

            session.Send(nameCache);
        }

        [Opcode(ClientMessage.RealmCache, "16135")]
        public static void HandleRealmCache(ref PacketReader packet, ref WorldClass session)
        {
            Character pChar = session.Character;

            uint realmId = packet.ReadUInt32();

            SQLResult result = DB.Realms.Select("SELECT name FROM realms WHERE id = '{0}'", WorldConfig.RealmId);
            string realmName = result.Read<string>(0, "Name");

            PacketWriter nameCache = new PacketWriter(LegacyMessage.RealmCache);

            nameCache.WriteUInt32(realmId);
            nameCache.WriteUInt8(0);              // < 0 => End of packet
            nameCache.WriteUInt8(1);              // Unknown
            nameCache.WriteCString(realmName);
            nameCache.WriteCString(realmName);

            session.Send(nameCache);
        }
    }
}
