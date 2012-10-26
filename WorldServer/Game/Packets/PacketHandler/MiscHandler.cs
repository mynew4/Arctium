using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Network;
using Framework.Logging;

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
    }
}
