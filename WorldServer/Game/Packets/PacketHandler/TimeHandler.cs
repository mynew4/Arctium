using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Game.Managers;
using WorldServer.Network;
using Framework.Constants.ObjectSettings;

namespace WorldServer.Game.PacketHandler
{
    public class TimeHandler : Globals
    {
        public static void HandleReadyForAccountDataTimes(ref PacketReader packet, ref WorldClass session)
        {
            WorldMgr.WriteAccountData(AccountDataMasks.GlobalCacheMask, ref session);
        }

        public static void HandleRequestUITime(ref PacketReader packet, ref WorldClass session)
        {
            PacketWriter uiTime = new PacketWriter(LegacyMessage.UITime);

            uiTime.WriteUnixTime();
            session.Send(uiTime);
        }
    }
}
