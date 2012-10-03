using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Framework.Constants;
using System.Collections;

namespace Framework.Network.Packets
{
    public class PacketWriter : BinaryWriter
    {
        public uint Opcode { get; set; }
        public ushort Size { get; set; }
        public byte[] Storage
        {
            get
            {
                byte[] data = new byte[BaseStream.Length - 4];
                Seek(4, SeekOrigin.Begin);

                for (int i = 0; i < BaseStream.Length - 4; i++)
                    data[i] = (byte)BaseStream.ReadByte();
                return data;
            }
        }

        public PacketWriter() : base(new MemoryStream()) { }
        public PacketWriter(JAMCCMessage message, bool isWorldPacket = false) : base(new MemoryStream())
        {
            SetMessageAndHeader((uint)message, isWorldPacket);
        }

        public PacketWriter(JAMCMessage message, bool isWorldPacket = false) : base(new MemoryStream())
        {
            SetMessageAndHeader((uint)message, isWorldPacket);
        }

        public PacketWriter(LegacyMessage message, bool isWorldPacket = false) : base(new MemoryStream())
        {
            SetMessageAndHeader((uint)message, isWorldPacket);
        }

        public PacketWriter(Message message, bool isWorldPacket = false) : base(new MemoryStream())
        {
            SetMessageAndHeader((uint)message, isWorldPacket);
        }

        void SetMessageAndHeader(uint mess, bool isWorldPacket)
        {
            Opcode = mess;
            WritePacketHeader(mess, isWorldPacket);
        }

        protected void WritePacketHeader(uint opcode, bool isWorldPacket = false)
        {
            Opcode = opcode;

            WriteUInt8(0);
            WriteUInt8(0);
            WriteUInt8((byte)(0xFF & opcode));
            WriteUInt8((byte)(0xFF & (opcode >> 8)));

            if (isWorldPacket)
            {
                WriteUInt8((byte)(0xFF & (opcode >> 16)));
                WriteUInt8((byte)(0xFF & (opcode >> 24)));
            }
        }

        public byte[] ReadDataToSend(bool isAuthPacket = false)
        {
            byte[] data = new byte[BaseStream.Length];
            Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < BaseStream.Length; i++)
                data[i] = (byte)BaseStream.ReadByte();


            Size = (ushort)(data.Length - 2);
            if (!isAuthPacket)
            {
                data[0] = (byte)(0xFF & Size);
                data[1] = (byte)(0xFF & (Size >> 8));
            }
           
            return data;
        }

        public void WriteInt8(sbyte data)
        {
            base.Write(data);
        }

        public void WriteInt16(short data)
        {
            base.Write(data);
        }

        public void WriteInt32(int data)
        {
            base.Write(data);
        }

        public void WriteInt64(long data)
        {
            base.Write(data);
        }

        public void WriteUInt8(byte data)
        {
            base.Write(data);
        }

        public void WriteUInt16(ushort data)
        {
            base.Write(data);
        }

        public void WriteUInt32(uint data)
        {
            base.Write(data);
        }

        public void WriteUInt64(ulong data)
        {
            base.Write(data);
        }

        public void WriteFloat(float data)
        {
            base.Write(data);
        }

        public void WriteDouble(double data)
        {
            base.Write(data);
        }

        public void WriteCString(string data)
        {
            byte[] sBytes = Encoding.ASCII.GetBytes(data);
            this.WriteBytes(sBytes);
            base.Write((byte)0);    // String null terminated
        }

        public void WriteString(string data)
        {
            byte[] sBytes = Encoding.ASCII.GetBytes(data);
            this.WriteBytes(sBytes);
        }

        public void WriteUnixTime()
        {
            DateTime baseDate = new DateTime(1970, 1, 1);
            DateTime currentDate = DateTime.Now;
            TimeSpan ts = currentDate - baseDate;

            WriteUInt32(Convert.ToUInt32(ts.TotalSeconds));
        }

        public void WriteGuid(ulong guid)
        {
            byte[] packedGuid = new byte[9];
            byte length = 1;

            for (byte i = 0; guid != 0; i++)
            {
                if ((guid & 0xFF) != 0)
                {
                    packedGuid[0] |= (byte)(1 << i);
                    packedGuid[length] = (byte)(guid & 0xFF);
                    ++length;
                }

                guid >>= 8;
            }

            WriteBytes(packedGuid, length);
        }

        public void WriteBytes(byte[] data, int count = 0)
        {
            if (count == 0)
                base.Write(data);
            else
                base.Write(data, 0, count);
        }

        public void WriteBitArray(BitArray buffer, int Len)
        {
            byte[] bufferarray = new byte[Convert.ToByte((buffer.Length + 8) / 8) + 1];
            buffer.CopyTo(bufferarray, 0);

            WriteBytes(bufferarray.ToArray(), Len);
        }
    }
}
