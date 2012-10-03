using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Game.Managers;
using WorldServer.Network;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class LogoutHandler : Globals
    {
        public static void HandleLogout(ref PacketReader packet, ref WorldClass session)
        {
            PacketWriter logoutComplete = new PacketWriter(LegacyMessage.LogoutComplete);

            session.Send(logoutComplete);
        }
    }
}
