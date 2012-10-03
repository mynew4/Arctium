using System.Collections.Generic;
using Framework.Constants;
using WorldServer.Network;

namespace Framework.Network.Packets
{
    public static class PacketManager
    {
        public static Dictionary<ClientMessage, HandlePacket> OpcodeHandlers = new Dictionary<ClientMessage, HandlePacket>();
        public delegate void HandlePacket(ref PacketReader packet, ref WorldClass session);

        public static void DefineOpcodeHandler(ClientMessage opcode, HandlePacket handler)
        {
            OpcodeHandlers[opcode] = handler;
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
