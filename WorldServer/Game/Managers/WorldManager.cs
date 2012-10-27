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
using Framework.Constants.ObjectSettings;
using Framework.Network.Packets;
using Framework.ObjectDefines;
using Framework.Singleton;
using System.Collections.Generic;
using WorldServer.Game.WorldEntities;
using WorldServer.Network;

namespace WorldServer.Game.Managers
{
    public sealed class WorldManager : SingletonBase<WorldManager>
    {
        public Dictionary<ulong, WorldClass> Sessions;
        public WorldClass Session { get; set; }

        WorldManager()
        {
            Sessions = new Dictionary<ulong, WorldClass>();
        }

        public void AddSession(ulong guid, ref WorldClass session)
        {
            Sessions.Add(guid, session);
        }

        public void DeleteSession(ulong guid)
        {
            Sessions.Remove(guid);
        }

        public void WriteAccountData(AccountDataMasks mask, ref WorldClass session)
        {
            PacketWriter accountInitialized = new PacketWriter(LegacyMessage.AccountDataInitialized);
            accountInitialized.WriteUnixTime();
            accountInitialized.WriteUInt8(0);
            accountInitialized.WriteUInt32((uint)mask);

            for (int i = 0; i <= 8; ++i)
                if (((int)mask & (1 << i)) != 0)
                    if (i == 1 && mask == AccountDataMasks.GlobalCacheMask)
                        accountInitialized.WriteUnixTime();
                    else
                        accountInitialized.WriteUInt32(0);

            session.Send(accountInitialized);
        }

        public void WriteUpdateObjectMovement(ref PacketWriter packet, ref Character character, UpdateFlag updateFlags)
        {
            ObjectMovementValues values = new ObjectMovementValues(updateFlags);

            BitPack BitPack = new BitPack(packet, character.Guid, character.GuildGuid);

            BitPack.Write(values.HasTarget);
            BitPack.Write(values.IsVehicle);
            BitPack.Write(values.BitCounter, 24);
            BitPack.Write(values.HasUnknown5);
            BitPack.Write(values.HasGoTransportPosition);
            BitPack.Write(values.HasStationaryPosition);
            BitPack.Write(values.BitCounter2, 21);
            BitPack.Write(values.HasUnknown);
            BitPack.Write(values.HasUnknown3);
            BitPack.Write(values.HasUnknown4);
            BitPack.Write(values.IsAlive);
            BitPack.Write(values.Bit1);
            BitPack.Write(values.HasUnknown2);
            BitPack.Write(values.Bit2);
            BitPack.Write(values.HasRotation);
            BitPack.Write(values.HasAnimKits);
            BitPack.Write(values.Bit3);
            BitPack.Write(values.IsSelf);

            if (values.IsAlive)
            {
                BitPack.WriteGuidMask(3);
                BitPack.Write(0);                   // HasSplineData, don't write simple basic splineData
                BitPack.Write(0, 24);               // BitCounter_Alive_1
                BitPack.WriteGuidMask(4);
                BitPack.Write(1);                   // Pitch or splineElevation, not implanted
                BitPack.Write(values.IsTransport);
                BitPack.Write(0);                   // IsInterpolated, not implanted
                BitPack.Write(!values.IsAlive);

                if (values.IsTransport)
                {
                    // Transports not implanted.
                }

                BitPack.Write(1);                   // Unknown_Alive_2, Reversed
                BitPack.WriteGuidMask(7);
                BitPack.Write(true);                // MovementFlags2 are not implanted
                BitPack.WriteGuidMask(0);
                BitPack.Write(0);                   // Unknown_Alive_1
                BitPack.WriteGuidMask(5);

                /* MovementFlags2 are not implanted
                 * if (movementFlag2 != 0)
                 * BitPack.Write(0, 12);*/

                BitPack.WriteGuidMask(2, 6);
                BitPack.Write(true);                // Movementflags are not implanted

                /* IsInterpolated, not implanted
                 * if (IsInterpolated)
                 * {
                 * BitPack.Write(0);               // IsFalling
                 * }*/

                /* Movementflags are not implanted
                if (movementFlags != 0)
                    BitPack.Write((uint)movementFlags, 30);*/

                BitPack.Write(!values.HasRotation);
                BitPack.Write(0);                   // Unknown_Alive_3
                BitPack.Write(0);                   // Unknown_Alive_4

                // Don't send basic spline data and disable advanced data
                //if (HasSplineData)
                {
                    //BitPack.Write(0);                   // Disable advance splineData
                }


                BitPack.WriteGuidMask(1);
                BitPack.Write(1);                   // Pitch or splineElevation, not implanted
            }

            BitPack.Flush();

            if (values.IsAlive)
            {

                // Don't send basic spline data
                /*if (HasSplineBasicData)
                {
                    // Advanced spline data not implanted
                    if (HasAdvancedSplineData)
                    {

                    }

                    packet.WriteFloat(character.X);
                    packet.WriteFloat(character.Y);
                    packet.WriteUInt32(0);
                    packet.WriteFloat(character.Z);
                }*/

                packet.WriteFloat((float)MovementSpeed.WalkSpeed);

                if (values.IsTransport)
                {
                    // Not implanted
                }

                BitPack.WriteGuidBytes(2);
                BitPack.WriteGuidBytes(7);
                packet.WriteUInt32(0);
                packet.WriteFloat((float)MovementSpeed.FlyBackSpeed);
                packet.WriteFloat(character.X);
                packet.WriteFloat(character.Y);
                BitPack.WriteGuidBytes(5);
                packet.WriteFloat(character.Z);
                BitPack.WriteGuidBytes(3, 6, 1);
                packet.WriteFloat((float)MovementSpeed.FlySpeed);
                packet.WriteFloat((float)MovementSpeed.PitchSpeed);
                packet.WriteFloat((float)MovementSpeed.RunSpeed);
                packet.WriteFloat(character.O);
                BitPack.WriteGuidBytes(4);
                packet.WriteFloat((float)MovementSpeed.SwimSpeed);
                packet.WriteFloat((float)MovementSpeed.RunBackSpeed);
                packet.WriteFloat((float)MovementSpeed.TurnSpeed);
                packet.WriteFloat((float)MovementSpeed.SwimBackSpeed);
                BitPack.WriteGuidBytes(0);
            }

            if (values.HasRotation)
            {
                // Packed orientation
                packet.WriteUInt64(0);
            }
        }
    }
}
