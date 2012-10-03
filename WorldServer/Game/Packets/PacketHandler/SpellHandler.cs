using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Game.Managers;
using WorldServer.Game.WorldEntities;

namespace WorldServer.Game.PacketHandler
{
    public class SpellHandler : Globals
    {
        public static void SendSendKnownSpells()
        {
            Character pChar = GetSession().Character;

            PacketWriter writer = new PacketWriter(LegacyMessage.SendKnownSpells);
            BitPack BitPack = new BitPack(writer);

            BitPack.Write(1);
            BitPack.Write<uint>((uint)pChar.Spells.Count, 24);
            BitPack.Flush();

            pChar.Spells.ForEach(spell =>
                writer.WriteUInt32(spell.Id));

            GetSession().Send(writer);
        }
    }
}
