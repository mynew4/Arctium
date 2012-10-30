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

        [ChatCommand("walkspeed")]
        public static void WalkSpeed(string[] args)
        {
            var session = GetSession();

            if (args.Length == 1)
                MoveHandler.HandleMoveSetWalkSpeed(ref session);
            else
            {
                var speed = CommandParser.Read<float>(args, 1);

                if (speed <= 50 && speed > 0)
                {
                    MoveHandler.HandleMoveSetWalkSpeed(ref session, speed);
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Walk speed set to " + speed + "!");
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Please enter a value between 0.0 and 50.0!");

                return;
            }

            ChatHandler.SendMessageByType(ref session, 0, 0, "Walk speed set to default.");
        }

        [ChatCommand("runspeed")]
        public static void RunSpeed(string[] args)
        {
            var session = GetSession();

            if (args.Length == 1)
                MoveHandler.HandleMoveSetRunSpeed(ref session);
            else
            {
                var speed = CommandParser.Read<float>(args, 1);
                if (speed <= 50 && speed > 0)
                {
                    MoveHandler.HandleMoveSetRunSpeed(ref session, speed);
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Run speed set to " + speed + "!");
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Please enter a value between 0.0 and 50.0!");

                return;
            }

            ChatHandler.SendMessageByType(ref session, 0, 0, "Run speed set to default.");
        }

        [ChatCommand("swimspeed")]
        public static void SwimSpeed(string[] args)
        {
            var session = GetSession();

            if (args.Length == 1)
                MoveHandler.HandleMoveSetSwimSpeed(ref session);
            else
            {
                var speed = CommandParser.Read<float>(args, 1);
                if (speed <= 50 && speed > 0)
                {
                    MoveHandler.HandleMoveSetSwimSpeed(ref session, speed);
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Swim speed set to " + speed + "!");
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Please enter a value between 0.0 and 50.0!");

                return;
            }

            ChatHandler.SendMessageByType(ref session, 0, 0, "Swim speed set to default.");
        }

        [ChatCommand("flightspeed")]
        public static void FlightSpeed(string[] args)
        {
            var session = GetSession();

            if (args.Length == 1)
                MoveHandler.HandleMoveSetFlightSpeed(ref session);
            else
            {
                var speed = CommandParser.Read<float>(args, 1);

                if (speed <= 50 && speed > 0)
                {
                    MoveHandler.HandleMoveSetFlightSpeed(ref session, speed);
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Flight speed set to " + speed + "!");
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Please enter a value between 0.0 and 50.0!");

                return;
            }

            ChatHandler.SendMessageByType(ref session, 0, 0, "Flight speed set to default.");
        }
    }
}
