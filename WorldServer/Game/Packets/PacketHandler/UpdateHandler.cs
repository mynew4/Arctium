using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Network;
using WorldServer.Game.WorldEntities;
using WorldServer.Game.Managers;
using System;

namespace WorldServer.Game.PacketHandler
{
    public class UpdateHandler : Globals
    {
        public static void HandleUpdateObject(ref PacketReader packet, ref WorldClass session)
        {
            Character character = session.Character;
            PacketWriter updateObject = new PacketWriter(LegacyMessage.UpdateObject);

            updateObject.WriteUInt16((ushort)character.Map);
            updateObject.WriteUInt32(1);  // Grml sandbox style...
            updateObject.WriteUInt8(1);
            updateObject.WriteGuid(character.Guid);
            updateObject.WriteUInt8(4);

            UpdateFlag updateFlags = UpdateFlag.Alive | UpdateFlag.Rotation | UpdateFlag.Self | UpdateFlag.Unknown4;
            WorldMgr.WriteUpdateObjectMovement(ref updateObject, ref character, updateFlags);
            character.WriteUpdateFields(ref updateObject);

            session.Send(updateObject);
        }
    }
}
