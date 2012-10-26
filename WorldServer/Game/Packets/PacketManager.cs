using Framework.Constants;
using System;
using System.Collections.Generic;
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
