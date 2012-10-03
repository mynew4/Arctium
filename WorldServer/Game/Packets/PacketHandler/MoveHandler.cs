using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Network;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class MoveHandler
    {
        public static void HandleMoveSetCanFly(ref WorldClass session)
        {
            PacketWriter setCanFly = new PacketWriter(JAMCMessage.MoveSetCanFly);
            BitPack BitPack = new BitPack(setCanFly, session.Character.Guid);

            BitPack.WriteGuidMask(7, 3, 1, 5, 0, 6, 2, 4);
            BitPack.Flush();

            setCanFly.WriteUInt32(0);

            BitPack.WriteGuidBytes(2, 6, 7, 1, 3, 4, 6, 0);
            session.Send(setCanFly);
        }
    }
}
