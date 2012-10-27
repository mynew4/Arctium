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
using WorldServer.Game.Managers;
using WorldServer.Network;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class ChatHandler : Globals
    {
        [Opcode(ClientMessage.ChatMessageSay, "16135")]
        public static void HandleMessageChat(ref PacketReader packet, ref WorldClass session)
        {
            BitUnpack BitUnpack = new BitUnpack(packet);

            int language = packet.ReadInt32();

            uint messageLength = BitUnpack.GetBits<uint>(9);
            string chatMessage = packet.ReadString(messageLength);

            PacketWriter messageChat = new PacketWriter(LegacyMessage.MessageChat);

            ulong guid = session.Character.Guid;

            messageChat.WriteUInt8(1);
            messageChat.WriteInt32(language);
            messageChat.WriteUInt64(guid);
            messageChat.WriteUInt32(0);
            messageChat.WriteUInt64(guid);
            messageChat.WriteUInt32(messageLength + 1);
            messageChat.WriteCString(chatMessage);
            messageChat.WriteUInt16(0);

            session.Send(messageChat);
        }
    }
}
