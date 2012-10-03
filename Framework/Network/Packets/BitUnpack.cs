using System;
using System.Linq;

namespace Framework.Network.Packets
{
    public class BitUnpack
    {
        public PacketReader reader;
        int Position;
        byte Value;

        public BitUnpack(PacketReader reader)
        {
            this.reader = reader;
            Position = 8;
            Value = 0;
        }

        public bool GetBit()
        {
            if (Position == 8)
            {
                Value = reader.ReadUInt8();
                Position = 0;
            }

            int returnValue = Value;
            Value = (byte)(2 * returnValue);
            ++Position;

            return Convert.ToBoolean(returnValue >> 7);
        }

        public T GetBits<T>(byte bitCount)
        {
            int returnValue = 0;

            for (var i = bitCount - 1 ; i >= 0; --i)
                returnValue = GetBit() ? (1 << i) | returnValue : returnValue;

            return (T)Convert.ChangeType(returnValue, typeof(T));
        }

        public T GetNameLength<T>(byte bitCount)
        {
            int returnValue = 0;

            // Unknown, always before namelength bits...
            GetBit();

            for (var i = bitCount - 1; i >= 0; --i)
                returnValue = GetBit() ? (1 << i) | returnValue : returnValue;

            return (T)Convert.ChangeType(returnValue, typeof(T));
        }

        public UInt64 GetGuid(byte[] mask, byte[] bytes)
        {
            bool[] guidMask = new bool[mask.Length];
            byte[] guidBytes = new byte[bytes.Length];

            for (int i = 0; i < guidMask.Length; i++)
                guidMask[i] = GetBit();

            for (byte i = 0; i < bytes.Length; i++)
                if (guidMask[mask[i]])
                    guidBytes[bytes[i]] = (byte)(reader.ReadUInt8() ^ 1);

            return BitConverter.ToUInt64(guidBytes, 0);
        }
    }
}
