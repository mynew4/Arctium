using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Game.Managers;
using WorldServer.Network;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class ChatHandler : Globals
    {
        public static void HandleChatMessageSay(ref PacketReader packet, ref WorldClass session)
        {
            BitUnpack BitUnpack = new BitUnpack(packet);

            int language = packet.ReadInt32();

            uint messageLength = BitUnpack.GetBits<uint>(9);
            string chatMessage = packet.ReadString(messageLength);

            PacketWriter messageChat = new PacketWriter(LegacyMessage.MessageChat);

            ulong guid = WorldMgr.Session.Character.Guid;

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
