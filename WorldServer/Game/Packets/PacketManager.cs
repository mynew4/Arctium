using Framework.Constants;
using System;
using System.Collections.Generic;
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

using System.Reflection;
using WorldServer.Network;

namespace Framework.Network.Packets
{
    public static class PacketManager
    {
        static Dictionary<ClientMessage, HandlePacket> OpcodeHandlers = new Dictionary<ClientMessage, HandlePacket>();
        delegate void HandlePacket(ref PacketReader packet, ref WorldClass session);

        public static void DefineOpcodeHandler()
        {
            Assembly currentAsm = Assembly.GetExecutingAssembly();
            foreach (var type in currentAsm.GetTypes())
            {
                foreach (var methodInfo in type.GetMethods())
                {
                    foreach (var opcodeAttr in methodInfo.GetCustomAttributes<OpcodeAttribute>())
                    {
                        OpcodeHandlers[opcodeAttr.Opcode] = (HandlePacket)Delegate.CreateDelegate(typeof(HandlePacket), methodInfo);
                    }
                }
            }
        }

        public static bool InvokeHandler(ref PacketReader reader, WorldClass session, ClientMessage opcode)
        {
            if (OpcodeHandlers.ContainsKey(opcode))
            {
                OpcodeHandlers[opcode].Invoke(ref reader, ref session);
                return true;
            }
            else
                return false;
        }
    }
}
