using System;
using Framework.Configuration;
using Framework.Constants;
using Framework.Constants.Authentication;
using Framework.Database;
using Framework.Network.Packets;
using Framework.ObjectDefines;
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

            SQLResult result = DB.Realms.Select("SELECT * FROM accounts WHERE name = '{0}'", accountName);
            if (result.Count == 0)
                session.clientSocket.Close();
            else
                session.Account = new Account()
                {
                    Id         = result.Read<int>(0, "id"),
                    Name       = result.Read<String>(0, "name"),
                    Password   = result.Read<String>(0, "password"),
                    SessionKey = result.Read<String>(0, "sessionkey"),
                    Expansion  = result.Read<byte>(0, "expansion"),
                    GMLevel    = result.Read<byte>(0, "gmlevel"),
                    IP         = result.Read<String>(0, "ip"),
                    Language   = result.Read<String>(0, "language")
                };

            string K = session.Account.SessionKey;
            byte[] kBytes = new byte[K.Length / 2];

            for (int i = 0; i < K.Length; i += 2)
                kBytes[i / 2] = Convert.ToByte(K.Substring(i, 2), 16);

            session.Crypt.Initialize(kBytes);

            uint realmId = WorldConfig.RealmId;
            SQLResult realmClassResult = DB.Realms.Select("SELECT class, expansion FROM realm_classes WHERE realmId = '{0}'", realmId);
            SQLResult realmRaceResult = DB.Realms.Select("SELECT race, expansion FROM realm_races WHERE realmId = '{0}'", realmId);

            PacketWriter authResponse = new PacketWriter(JAMCMessage.AuthResponse);
            BitPack BitPack = new BitPack(authResponse);

            BitPack.Write(1);                                      // HasAccountData
            BitPack.Write(0);                                      // Unknown, 5.0.4
            BitPack.Write(realmClassResult.Count, 25);              // Activation count for races
            BitPack.Write(0, 22);                                  // Activate character template windows/button
            BitPack.Write(realmRaceResult.Count, 25);             // Activation count for classes
            BitPack.Write(0);                                      // IsInQueue
            BitPack.Flush();

            authResponse.WriteUInt8(0);
            authResponse.WriteUInt8(session.Account.Expansion);

            for (int c = 0; c < realmClassResult.Count; c++)
            {
                authResponse.WriteUInt8(realmClassResult.Read<byte>(c, "class"));
                authResponse.WriteUInt8(realmClassResult.Read<byte>(c, "expansion"));
            }

            authResponse.WriteUInt32(0);
            authResponse.WriteUInt32(0);
            authResponse.WriteUInt32(0);


            for (int r = 0; r < realmRaceResult.Count; r++)
            {
                authResponse.WriteUInt8(realmRaceResult.Read<byte>(r, "race"));
                authResponse.WriteUInt8(realmRaceResult.Read<byte>(r, "expansion"));
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
