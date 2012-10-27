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
using WorldServer.Network;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class LogoutHandler : Globals
    {
        [Opcode(ClientMessage.Logout, "")]
        public static void HandleLogoutComplete(ref PacketReader packet, ref WorldClass session)
        {
            PacketWriter logoutComplete = new PacketWriter(LegacyMessage.LogoutComplete);

            session.Send(logoutComplete);
        }
    }
}
