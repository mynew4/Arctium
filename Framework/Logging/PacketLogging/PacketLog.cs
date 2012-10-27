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
using Framework.Network.Packets;
using System;
using System.IO;
using System.Linq;

namespace Framework.Logging.PacketLogging
{
    public class PacketLog
    {
        public static void WritePacket(string clientInfo, PacketWriter serverPacket = null, PacketReader clientPacket = null)
        {
            using (StreamWriter logWriter = File.AppendText("Packet.log"))
            {
                if (serverPacket != null)
                {
                    logWriter.WriteLine(String.Format("Client: {0}", clientInfo));

                    if (Enum.IsDefined(typeof(LegacyMessage), serverPacket.Opcode))
                    {
                        logWriter.WriteLine("Type: LegacyMessage");
                        logWriter.WriteLine(String.Format("Name: {0}", Enum.GetName(typeof(LegacyMessage), serverPacket.Opcode)));
                    }
                    else if (Enum.IsDefined(typeof(JAMCMessage), serverPacket.Opcode))
                    {
                        logWriter.WriteLine("Type: JAMCMessage");
                        logWriter.WriteLine(String.Format("Name: {0}", Enum.GetName(typeof(JAMCMessage), serverPacket.Opcode)));
                    }
                    else if (Enum.IsDefined(typeof(Message), serverPacket.Opcode))
                    {
                        logWriter.WriteLine("Type: Message");
                        logWriter.WriteLine(String.Format("Name: {0}", Enum.GetName(typeof(Message), serverPacket.Opcode)));
                    }
                    else
                    {
                        logWriter.WriteLine("Type: JAMCCMessage");
                        logWriter.WriteLine(String.Format("Name: {0}", Enum.GetName(typeof(JAMCCMessage), serverPacket.Opcode)));
                    }

                    logWriter.WriteLine(String.Format("Value: 0x{0:X} ({1})", serverPacket.Opcode, serverPacket.Opcode));
                    logWriter.WriteLine(String.Format("Length: {0}", serverPacket.Size - 2));

                    logWriter.WriteLine("|----------------------------------------------------------------|");
                    logWriter.WriteLine("| 00  01  02  03  04  05  06  07  08  09  0A  0B  0C  0D  0E  0F |");
                    logWriter.WriteLine("|----------------------------------------------------------------|");
                    logWriter.Write("|");

                    if (serverPacket.Size - 2 != 0)
                    {
                        var data = serverPacket.ReadDataToSend().ToList();
                        data.RemoveRange(0, 4);

                        byte count = 0;
                        data.ForEach(b =>
                        {
                            if (b <= 0xF)
                                logWriter.Write(String.Format(" 0{0:X} ", b));
                            else
                                logWriter.Write(String.Format(" {0:X} ", b));

                            if (count == 15)
                            {
                                logWriter.Write("|");
                                logWriter.WriteLine();
                                logWriter.Write("|");
                                count = 0;
                            }
                            else
                                count++;
                        });

                        logWriter.WriteLine("");
                        logWriter.WriteLine("|----------------------------------------------------------------|");
                    }

                    logWriter.WriteLine("");
                    logWriter.WriteLine("");


                    logWriter.Close();
                }

                if (clientPacket != null)
                {
                    logWriter.WriteLine(String.Format("Client: {0}", clientInfo));
                    logWriter.WriteLine("Type: ClientMessage");

                    if (Enum.IsDefined(typeof(ClientMessage), clientPacket.Opcode))
                        logWriter.WriteLine(String.Format("Name: {0}", clientPacket.Opcode));
                    else
                        logWriter.WriteLine(String.Format("Name: {0}", "Unknown"));

                    logWriter.WriteLine(String.Format("Value: 0x{0:X} ({1})", (ushort)clientPacket.Opcode, (ushort)clientPacket.Opcode));
                    logWriter.WriteLine(String.Format("Length: {0}", clientPacket.Size));

                    logWriter.WriteLine("|----------------------------------------------------------------|");
                    logWriter.WriteLine("| 00  01  02  03  04  05  06  07  08  09  0A  0B  0C  0D  0E  0F |");
                    logWriter.WriteLine("|----------------------------------------------------------------|");
                    logWriter.Write("|");

                    if (clientPacket.Size - 2 != 0)
                    {
                        var data = clientPacket.Storage.ToList();

                        byte count = 0;
                        data.ForEach(b =>
                        {

                            if (b <= 0xF)
                                logWriter.Write(String.Format(" 0{0:X} ", b));
                            else
                                logWriter.Write(String.Format(" {0:X} ", b));

                            if (count == 15)
                            {
                                logWriter.Write("|");
                                logWriter.WriteLine();
                                logWriter.Write("|");
                                count = 0;
                            }
                            else
                                count++;
                        });

                        logWriter.WriteLine();
                        logWriter.Write("|----------------------------------------------------------------|");
                    }

                    logWriter.WriteLine("");
                    logWriter.WriteLine("");

                    logWriter.Close();
                }
            }
        }
    }
}
