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
