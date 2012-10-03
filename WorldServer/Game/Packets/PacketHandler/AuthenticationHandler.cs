using Framework.Configuration;
using Framework.Constants;
using Framework.Constants.Authentication;
using Framework.Network.Packets;
using Framework.ObjectDefines;
using System;
using WorldServer.Game.Managers;
using WorldServer.Network;

namespace WorldServer.Game.PacketHandler
{
    public class AuthenticationHandler : Globals
    {
        public static void HandleTransferInitiate(ref PacketReader packet, ref WorldClass session)
        {
            PacketWriter authChallenge = new PacketWriter(JAMCCMessage.AuthChallenge, true);

            authChallenge.WriteUInt32((uint)new Random(DateTime.Now.Second).Next(1, 0xFFFFFFF));

            for (int i = 0; i < 8; i++)
                authChallenge.WriteUInt32(0);

            authChallenge.WriteUInt8(1);

            session.Send(authChallenge);
        }

        public static void HandleAuthSession(ref PacketReader packet, ref WorldClass session)
        {
            BitUnpack BitUnpack = new BitUnpack(packet);

            packet.Skip(54);

            int addonSize = packet.ReadInt32();
            packet.Skip(addonSize);

            uint nameLength = BitUnpack.GetNameLength<uint>(12);
            string accountName = packet.ReadString(nameLength);

            Account result = Account.GetAccountByName(accountName);
            if (result == null)
                session.clientSocket.Close();
            else
                session.Account = new Account()
                {
                    Id         = result.Id,
                    Name       = result.Name,
                    Password   = result.Password,
                    SessionKey = result.SessionKey,
                    Expansion  = result.Expansion,
                    GMLevel    = result.GMLevel,
                    IP         = result.IP,
                    Language   = result.Language
                };

            string K = session.Account.SessionKey;
            byte[] kBytes = new byte[K.Length / 2];

            for (int i = 0; i < K.Length; i += 2)
                kBytes[i / 2] = Convert.ToByte(K.Substring(i, 2), 16);

            session.Crypt.Initialize(kBytes);

            Realm realm = Realm.GetRealmById(WorldConfig.RealmId);

            PacketWriter authResponse = new PacketWriter(JAMCMessage.AuthResponse);
            BitPack BitPack = new BitPack(authResponse);

            BitPack.Write(1);                                      // HasAccountData
            BitPack.Write(0);                                      // Unknown, 5.0.4
            BitPack.Write(realm.RealmClasses.Count, 25);           // Activation count for classes
            BitPack.Write(0, 22);                                  // Activate character template windows/button
            BitPack.Write(realm.RealmRaces.Count, 25);             // Activation count for races
            BitPack.Write(0);                                      // IsInQueue
            BitPack.Flush();

            authResponse.WriteUInt8(0);
            authResponse.WriteUInt8(session.Account.Expansion);

            foreach (var kp in realm.RealmClasses)
            {
                authResponse.WriteUInt8((byte)kp.Key);
                authResponse.WriteUInt8((byte)kp.Value);
            }

            authResponse.WriteUInt32(0);
            authResponse.WriteUInt32(0);
            authResponse.WriteUInt32(0);

            foreach (var kp in realm.RealmRaces)
            {
                authResponse.WriteUInt8((byte)kp.Key);
                authResponse.WriteUInt8((byte)kp.Value);
            }

            authResponse.WriteUInt8(session.Account.Expansion);
            authResponse.WriteUInt8((byte)AuthCodes.AUTH_OK);

            session.Send(authResponse);

            PacketWriter tutorialFlags = new PacketWriter(LegacyMessage.TutorialFlags);
            for (int i = 0; i < 8; i++)
                tutorialFlags.WriteUInt32(0);

            session.Send(tutorialFlags);
        }
    }
}
