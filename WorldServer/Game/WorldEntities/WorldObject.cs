using System;
using System.Collections;
using Framework.Network.Packets;
using Framework.Logging;

namespace WorldServer.Game.WorldEntities
{
    public struct ObjectPosition
    {
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Orientation { get; set; }
    }

    public class WorldObject
    {
        public bool IsInWorld { get; set; }
        public uint Blocks;
        public byte[] Mask;
        public int DataLength;
        public Hashtable UpdateData = new Hashtable();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataLength">UpdateFields.cs enum End fields</param>
        /// <returns></returns>
        public WorldObject() { }
        public WorldObject(int dataLength)
        {
            IsInWorld = false;
            DataLength = dataLength;
            Blocks = (uint)(DataLength + 31) / 32;
            Mask = new byte[(Blocks * 4) << 2];
        }

        public void SetUpdateField<T>(int index, T value, byte offset = 0)
        {
            switch (value.GetType().Name)
            {
                case "Byte":
                case "UInt16":
                {
                    SetBit(index);

                    if (UpdateData.ContainsKey(index))
                        UpdateData[index] = (uint)((uint)UpdateData[index] | (uint)((uint)Convert.ChangeType(value, typeof(uint)) << (offset * (value.GetType().Name == "Byte" ? 8 : 16))));
                    else
                        UpdateData[index] = (uint)((uint)Convert.ChangeType(value, typeof(uint)) << (offset * (value.GetType().Name == "Byte" ? 8 : 16)));

                    break;
                }
                case "UInt64":
                {
                    SetBit(index);
                    SetBit(index + 1);

                    ulong tmpValue = (ulong)Convert.ChangeType(value, typeof(ulong));

                    UpdateData[index] = (uint)(tmpValue & UInt32.MaxValue);
                    UpdateData[index + 1] = (uint)((tmpValue >> 32) & UInt32.MaxValue);
                    
                    break;
                }
                case "Int32":
                case "UInt32":
                case "Single":
                default:
                {
                    SetBit(index);
                    UpdateData[index] = value;

                    break;
                }
            }
        }

        public void WriteUpdateFields(ref PacketWriter packet, bool sendAllFields = true)
        {
            packet.WriteUInt8((byte)Blocks);
            packet.Write(Mask, 0, (int)Blocks * 4);

            for (int i = 0; i < DataLength; i++)
            {
                if (GetBit(i))
                {
                    try
                    {
                        switch (UpdateData[i].GetType().Name)
                        {
                            /*case "Int16":
                                packet.WriteInt16((short)UpdateData[i]);
                                break;
                            case "UInt16":
                                packet.WriteUInt16((ushort)UpdateData[i]);
                                break;*/
                            case "Int32":
                                packet.WriteInt32((int)UpdateData[i]);
                                break;
                            case "UInt32":
                                packet.WriteUInt32((uint)UpdateData[i]);
                                break;
                            case "Single":
                                packet.WriteFloat((float)UpdateData[i]);
                                break;
                            default:
                                packet.WriteInt32((int)UpdateData[i]);
                                break;
                        }
                    }
                    catch
                    {
                        if (sendAllFields)
                            packet.WriteInt32(0);
                    }
                }
            }
        }

        public void SetBit(int index)
        {
            Mask[index >> 3] |= (byte)(1 << (index & 0x7));
        }

        public bool GetBit(int index)
        {
            return (Mask[index >> 3] & 1 << (index & 0x7)) != 0;
        }

        public void AddToWorld()
        {

        }

        public void RemoveFromWorld()
        {

        }
    }
}
