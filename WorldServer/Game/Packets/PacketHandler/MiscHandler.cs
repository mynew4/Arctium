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
using Framework.Logging;
using Framework.Network.Packets;
using WorldServer.Network;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class MiscHandler
    {
        public static void HandleMessageOfTheDay(ref WorldClass session)
        {
            PacketWriter motd = new PacketWriter(LegacyMessage.MessageOfTheDay);
            motd.WriteUInt32(3);

            motd.WriteCString("Arctium MoP test");
            motd.WriteCString("Welcome to our MoP server test.");
            motd.WriteCString("Your development team =)");
            session.Send(motd);
        }

        [Opcode(ClientMessage.Ping, "16135")]
        public static void HandlePong(ref PacketReader packet, ref WorldClass session)
        {
            uint sequence = packet.ReadUInt32();
            uint latency = packet.ReadUInt32();

            PacketWriter pong = new PacketWriter(JAMCCMessage.Pong);
            pong.WriteUInt32(sequence);

            session.Send(pong);
        }

        [Opcode(ClientMessage.LogDisconnect, "16135")]
        public static void HandleDisconnectReason(ref PacketReader packet, ref WorldClass session)
        {
            uint disconnectReason = packet.ReadUInt32();

            Log.Message(LogType.DEBUG, "Account with Id {0} disconnected. Reason: {1}", session.Account.Id, disconnectReason);
        }

        public static void HandleUpdateClientCacheVersion(ref WorldClass session)
        {
            PacketWriter cacheVersion = new PacketWriter(LegacyMessage.UpdateClientCacheVersion);

            cacheVersion.WriteUInt32(0);

            session.Send(cacheVersion);
        }
    }
}
