using System;
using System.Collections;
using System.Net.Sockets;
using Framework.Constants;
using Framework.Cryptography;
using Framework.Logging;
using Framework.Network.Packets;
using Framework.ObjectDefines;
using WorldServer.Game.Managers;
using WorldServer.Game.WorldEntities;
using Framework.Logging.PacketLogging;
using System.Net;

namespace WorldServer.Network
{
    public class WorldClass
    {
        public Account Account { get; set; }
        public Character Character { get; set; }
        public static WorldNetwork world;
        public Socket clientSocket;
        public Queue PacketQueue;
        public PacketCrypt Crypt;
        byte[] DataBuffer;

        public WorldClass()
        {
            DataBuffer = new byte[8192];
            PacketQueue = new Queue();
            Crypt = new PacketCrypt();
        }

        public void OnData()
        {
            PacketReader packet = null;
            if (PacketQueue.Count > 0)
                packet = (PacketReader)PacketQueue.Dequeue();
            else
                packet = new PacketReader(DataBuffer);

            string clientInfo = ((IPEndPoint)clientSocket.RemoteEndPoint).Address + ":" + ((IPEndPoint)clientSocket.RemoteEndPoint).Port;
            PacketLog.WritePacket(clientInfo, null, packet);

            if (Enum.IsDefined(typeof(ClientMessage), packet.Opcode))
                PacketManager.InvokeHandler(ref packet, this, (ClientMessage)packet.Opcode);
            else
                Log.Message(LogType.DUMP, "UNKNOWN OPCODE: {0} (0x{1:X}), LENGTH: {2}", packet.Opcode, (ushort)packet.Opcode, packet.Size);
        }

        public void OnConnect()
        {
            PacketWriter TransferInitiate = new PacketWriter(Message.TransferInitiate);
            TransferInitiate.WriteCString("RLD OF WARCRAFT CONNECTION - SERVER TO CLIENT");

            Send(TransferInitiate);

            clientSocket.BeginReceive(DataBuffer, 0, DataBuffer.Length, SocketFlags.None, Receive, null);
        }

        public void Receive(IAsyncResult result)
        {
            try
            {
                var recievedBytes = clientSocket.EndReceive(result);
                if (recievedBytes != 0)
                {
                    if (Crypt.IsInitialized)
                        while (recievedBytes > 0)
                        {
                            Decode(ref DataBuffer);

                            var length = BitConverter.ToUInt16(DataBuffer, 0) + 4;

                            var packetData = new byte[length];
                            Array.Copy(DataBuffer, packetData, length);

                            PacketReader packet = new PacketReader(packetData);
                            PacketQueue.Enqueue(packet);

                            recievedBytes -= length;
                            Array.Copy(DataBuffer, length, DataBuffer, 0, recievedBytes);
                            OnData();
                        }
                    else
                        OnData();

                    clientSocket.BeginReceive(DataBuffer, 0, DataBuffer.Length, SocketFlags.None, Receive, null);
                }
            }
            catch (Exception ex)
            {
            	Log.Message(LogType.ERROR, "{0}", ex.Message);
                Log.Message();
            }
        }

        protected void Decode(ref byte[] data)
        {
            Crypt.Decrypt(data);

            var header = BitConverter.ToUInt32(data, 0);
            ushort size = (ushort)(header >> 12);
            ushort opcode = (ushort)(header & 0xFFF);

            data[0] = (byte)(0xFF & size);
            data[1] = (byte)(0xFF & (size >> 8));
            data[2] = (byte)(0xFF & opcode);
            data[3] = (byte)(0xFF & (opcode >> 8));
        }

        public void Send(PacketWriter packet)
        {
            if (packet.Opcode == 0)
                return;

            var buffer = packet.ReadDataToSend();

            try
            {
                if (Crypt.IsInitialized)
                {
                    uint totalLength = (uint)packet.Size - 2;
                    totalLength <<= 12;
                    totalLength |= ((uint)packet.Opcode & 0xFFF);

                    var header = BitConverter.GetBytes(totalLength);

                    Crypt.Encrypt(header);

                    buffer[0] = header[0];
                    buffer[1] = header[1];
                    buffer[2] = header[2];
                    buffer[3] = header[3];
                }

                clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(FinishSend), null);
                packet.Flush();

                string clientInfo = ((IPEndPoint)clientSocket.RemoteEndPoint).Address + ":" + ((IPEndPoint)clientSocket.RemoteEndPoint).Port;
                PacketLog.WritePacket(clientInfo, packet);
            }
            catch (Exception ex)
            {
                Log.Message(LogType.ERROR, "{0}", ex.Message);
                Log.Message();

                clientSocket.Close();
            }
        }

        public void FinishSend(IAsyncResult result)
        {
            clientSocket.EndSend(result);
        }
    }
}
