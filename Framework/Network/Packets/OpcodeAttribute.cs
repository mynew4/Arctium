using Framework.Constants;
using System;

namespace Framework.Network.Packets
{
    public class OpcodeAttribute : Attribute
    {
        public ClientMessage Opcode { get; set; }
        public string WoWBuild { get; set; }

        public OpcodeAttribute(ClientMessage ocpode, string wowBuild)
        {
            Opcode = ocpode;
            WoWBuild = wowBuild;
        }
    }
}
