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
using System;
using System.IO;
using System.Text;

namespace Framework.Network.Packets
{
    public class PacketReader : BinaryReader
    {
        public ClientMessage Opcode { get; set; }
        public ushort Size { get; set; }
        public byte[] Storage { get; set; }

        public PacketReader(byte[] data, bool worldPacket = true) : base(new MemoryStream(data))
        {
            if (worldPacket)
            {
                ushort size = this.ReadUInt16();
                Opcode = (ClientMessage)this.ReadUInt16();

                if (Opcode == ClientMessage.TransferInitiate)
                    Size = (ushort)((size % 0x100) + (size / 0x100));
                else
                    Size = size;

                Storage = new byte[Size];
                Array.Copy(data, 4, Storage, 0, Size);
            }
        }

        public sbyte ReadInt8()
        {
            return base.ReadSByte();
        }

        public new short ReadInt16()
        {
            return base.ReadInt16();
        }

        public new int ReadInt32()
        {
            return base.ReadInt32();
        }

        public new long ReadInt64()
        {
            return base.ReadInt64();
        }

        public byte ReadUInt8()
        {
            return base.ReadByte();
        }

        public new ushort ReadUInt16()
        {
            return base.ReadUInt16();
        }

        public new uint ReadUInt32()
        {
            return base.ReadUInt32();
        }

        public new ulong ReadUInt64()
        {
            return base.ReadUInt64();
        }

        public float ReadFloat()
        {
            return base.ReadSingle();
        }

        public new double ReadDouble()
        {
            return base.ReadDouble();
        }

        public string ReadCString()
        {
            StringBuilder tmpString = new StringBuilder();
            char tmpChar = base.ReadChar();
            char tmpEndChar = Convert.ToChar(Encoding.UTF8.GetString(new byte[] { 0 }));

            while (tmpChar != tmpEndChar)
            {
                tmpString.Append(tmpChar);
                tmpChar = base.ReadChar();
            }

            return tmpString.ToString();
        }

        public string ReadString(uint count)
        {
            byte[] stringArray = ReadBytes(count);
            return Encoding.ASCII.GetString(stringArray);
        }

        public byte[] ReadBytes(uint count)
        {
            return base.ReadBytes((int)count);
        }

        public string ReadStringFromBytes(uint count)
        {
            byte[] stringArray = ReadBytes(count);
            Array.Reverse(stringArray);

            return Encoding.ASCII.GetString(stringArray);
        }

        public string ReadIPAddress()
        {
            byte[] ip = new byte[4];

            for (int i = 0; i < 4; ++i)
                ip[i] = ReadUInt8();

            return ip[0] + "." + ip[1] + "." + ip[2] + "." + ip[3];
        }

        public string ReadAccountName()
        {
            StringBuilder nameBuilder = new StringBuilder();

            byte nameLength = ReadUInt8();
            char[] name = new char[nameLength];

            for (int i = 0; i < nameLength; i++)
            {
                name[i] = base.ReadChar();
                nameBuilder.Append(name[i]);
            }

            return nameBuilder.ToString().ToUpper();
        }

        public void Skip(int count)
        {
            base.BaseStream.Position += count;
        }
    }
}
