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

using Framework.Console;
using WorldServer.Game.Managers;
using WorldServer.Game.Packets.PacketHandler;

namespace WorldServer.Game.Chat.Commands
{
    public class MovementCommands : Globals
    {
        [ChatCommand("fly")]
        public static void Fly(string[] args)
        {
            string state = CommandParser.Read<string>(args, 1);
            var session = GetSession();

            if (state == "on")
            {
                MoveHandler.HandleMoveSetCanFly(ref session);
                ChatHandler.SendMessageByType(ref session, 0, 0, "Fly mode enabled.");
            }
            else if (state == "off")
            {
                MoveHandler.HandleMoveUnsetCanFly(ref session);
                ChatHandler.SendMessageByType(ref session, 0, 0, "Fly mode disabled.");
            }
        }
    }
}
