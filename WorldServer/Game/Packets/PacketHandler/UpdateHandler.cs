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
using WorldServer.Game.WorldEntities;
using WorldServer.Network;

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
