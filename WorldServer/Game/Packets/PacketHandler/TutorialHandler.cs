using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Network;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class TutorialHandler
    {
        public static void HandleTutorialFlags(ref WorldClass session)
        {
            PacketWriter tutorialFlags = new PacketWriter(LegacyMessage.TutorialFlags);
            for (int i = 0; i < 8; i++)
                tutorialFlags.WriteUInt32(0);

            session.Send(tutorialFlags);
        }
    }
}
