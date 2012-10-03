using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Framework.Cryptography;
using Framework.Network.Packets;
using Framework.Constants.Authentication;
using Framework.ObjectDefines;
using Framework.Logging;
using Framework.Database;
using Framework.Configuration;
using System.Collections.Generic;

namespace Framework.Network.Realm
{
    public class RealmClass
    {
        public static Account Account { get; set; }
        public static List<ObjectDefines.Realm> Realms = new List<ObjectDefines.Realm>();
        public static RealmNetwork realm;
        public SRP6 SecureRemotePassword { get; set; }
        public Socket clientSocket;
        byte[] DataBuffer;
        Account account;

        public RealmClass()
        {
            Account = new Account();
            SecureRemotePassword = new SRP6();
        }

        void HandleRealmData(byte[] data)
        {
            PacketReader reader = new PacketReader(data, false);
            ClientLink cmd = (ClientLink)reader.ReadUInt8();

            switch (cmd)
            {
                case ClientLink.CMD_AUTH_LOGON_CHALLENGE:
                case ClientLink.CMD_AUTH_RECONNECT_CHALLENGE:
                    HandleAuthLogonChallenge(this, reader);
                    break;
                case ClientLink.CMD_AUTH_LOGON_PROOF:
                case ClientLink.CMD_AUTH_RECONNECT_PROOF:
                    HandleAuthLogonProof(this, reader);
                    break;
                case ClientLink.CMD_REALM_LIST:
                    HandleRealmList(this, reader);
                    break;
                default:
                    Log.Message(LogType.NORMAL, "Received unknown ClientLink: {0}", cmd);
                    break;
            }
        }

        public void HandleAuthLogonChallenge(RealmClass session, PacketReader data)
        {
            Log.Message(LogType.NORMAL, "AuthLogonChallenge");

            data.Skip(10);
            ushort ClientBuild = data.ReadUInt16();
            data.Skip(8);
            Account.Language = data.ReadStringFromBytes(4);
            data.Skip(4);

            Account.IP = data.ReadIPAddress();
            Account.Name = data.ReadAccountName();

            account = Account.GetAccountByName(Account.Name);

            PacketWriter logonChallenge = new PacketWriter();
            logonChallenge.WriteUInt8((byte)ClientLink.CMD_AUTH_LOGON_CHALLENGE);
            logonChallenge.WriteUInt8(0);

            if (account != null)
            {
                Account.Id = account.Id;
                Account.Expansion = account.Expansion;
                Account.SecurityFlags = account.SecurityFlags;

                account.IP = Account.IP;
                account.Language = Account.Language;

                byte[] username = Encoding.ASCII.GetBytes(account.Name.ToUpper());
                byte[] password = Encoding.ASCII.GetBytes(account.Password.ToUpper());

                // WoW 5.0.5.16057 (5.0.5a)
                if (ClientBuild == 16057)
                {
                    session.SecureRemotePassword.CalculateX(username, password);
                    byte[] buf = new byte[0x10];
                    SRP6.RAND_bytes(buf, 0x10);

                    logonChallenge.WriteUInt8((byte)AuthResults.WOW_SUCCESS);
                    logonChallenge.WriteBytes(session.SecureRemotePassword.B);
                    logonChallenge.WriteUInt8(1);
                    logonChallenge.WriteUInt8(session.SecureRemotePassword.g[0]);
                    logonChallenge.WriteUInt8(0x20);
                    logonChallenge.WriteBytes(session.SecureRemotePassword.N);
                    logonChallenge.WriteBytes(session.SecureRemotePassword.salt);
                    logonChallenge.WriteBytes(buf);

                    // Security flags
                    logonChallenge.WriteUInt8(Account.SecurityFlags);

                    // Enable authenticator
                    if ((Account.SecurityFlags & 4) != 0)
                        logonChallenge.WriteUInt8(1);

                    DB.RealmDB.Save(account);
                }
            }
            else
                logonChallenge.WriteUInt8((byte)AuthResults.WOW_FAIL_UNKNOWN_ACCOUNT);

            session.Send(logonChallenge);
        }

        public void HandleAuthAuthenticator(RealmClass session, PacketReader data)
        {
            Log.Message(LogType.NORMAL, "AuthAuthenticator");
        }

        public void HandleAuthLogonProof(RealmClass session, PacketReader data)
        {
            Log.Message(LogType.NORMAL, "AuthLogonProof");

            PacketWriter logonProof = new PacketWriter();

            byte[] a = new byte[32];
            byte[] m1 = new byte[20];

            Array.Copy(DataBuffer, 1, a, 0, 32);
            Array.Copy(DataBuffer, 33, m1, 0, 20);

            session.SecureRemotePassword.CalculateU(a);
            session.SecureRemotePassword.CalculateM2(m1);
            session.SecureRemotePassword.CalculateK();

            foreach (var b in session.SecureRemotePassword.K)
                if (b < 0x10)
                    Account.SessionKey += "0" + String.Format("{0:X}", b);
                else
                    Account.SessionKey += String.Format("{0:X}", b);

            logonProof.WriteUInt8((byte)ClientLink.CMD_AUTH_LOGON_PROOF);
            logonProof.WriteUInt8(0);
            logonProof.WriteBytes(session.SecureRemotePassword.M2);
            logonProof.WriteUInt32(0x800000);
            logonProof.WriteUInt32(0);
            logonProof.WriteUInt16(0);

            account.SessionKey = Account.SessionKey;
            DB.RealmDB.Save(account);

            session.Send(logonProof);
        }

        public void HandleRealmList(RealmClass session, PacketReader data)
        {
            Log.Message(LogType.NORMAL, "RealmList");

            PacketWriter realmData = new PacketWriter();

            Realms.ForEach(r =>
            {
                realmData.WriteUInt8(1);
                realmData.WriteUInt8(0);
                realmData.WriteUInt8(0);
                realmData.WriteCString(r.Name);
                realmData.WriteCString(r.IP + ":" + r.Port);
                realmData.WriteFloat(0);
                realmData.WriteUInt8(0);  // CharCount
                realmData.WriteUInt8(1);
                realmData.WriteUInt8(0x2C);
            });

            PacketWriter realmList = new PacketWriter();
            realmList.WriteUInt8((byte)ClientLink.CMD_REALM_LIST);
            realmList.WriteUInt16((ushort)(realmData.BaseStream.Length + 8));
            realmList.WriteUInt32(0);
            realmList.WriteUInt16((ushort)Realms.Count);
            realmList.WriteBytes(realmData.ReadDataToSend());
            realmList.WriteUInt8(0);
            realmList.WriteUInt8(0x10);

            session.Send(realmList);
        }

        public void Recieve()
        {
            while (realm.listenSocket)
            {
                Thread.Sleep(1);
                if (clientSocket.Available > 0)
                {
                    DataBuffer = new byte[clientSocket.Available];
                    clientSocket.Receive(DataBuffer, DataBuffer.Length, SocketFlags.None);

                    HandleRealmData(DataBuffer);
                }
            }

            clientSocket.Close();
        }

        public void Send(PacketWriter packet)
        {
            DataBuffer = packet.ReadDataToSend(true);

            try
            {
                clientSocket.BeginSend(DataBuffer, 0, DataBuffer.Length, SocketFlags.None, new AsyncCallback(FinishSend), clientSocket);
                packet.Flush();
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
