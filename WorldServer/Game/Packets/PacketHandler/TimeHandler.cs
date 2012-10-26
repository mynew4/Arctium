using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Game.Managers;
using WorldServer.Network;
using Framework.Constants.ObjectSettings;

namespace WorldServer.Game.PacketHandler
{
    public class TimeHandler : Globals
    {
        [Opcode(ClientMessage.ReadyForAccountDataTimes, "16135")]
        public static void HandleAccountDataInitialized(ref PacketReader packet, ref WorldClass session)
        {
            WorldMgr.WriteAccountData(AccountDataMasks.GlobalCacheMask, ref session);
        }

        [Opcode(ClientMessage.RequestUITime, "")]
        public static void HandleUITime(ref PacketReader packet, ref WorldClass session)
        {
            PacketWriter uiTime = new PacketWriter(LegacyMessage.UITime);

            uiTime.WriteUnixTime();

            session.Send(uiTime);
        }

        [Opcode(ClientMessage.SetRealmSplitState, "16135")]
        public static void HandleRealmSplitStateResponse(ref PacketReader packet, ref WorldClass session)
        {
            uint realmSplitState = 0;

            PacketWriter realmSplitStateResp = new PacketWriter(LegacyMessage.RealmSplitStateResponse);

            realmSplitStateResp.WriteUInt32(packet.ReadUInt32());
            realmSplitStateResp.WriteUInt32(realmSplitState);
            realmSplitStateResp.WriteCString("01/01/01");

            session.Send(realmSplitStateResp);
        }
    }
}
