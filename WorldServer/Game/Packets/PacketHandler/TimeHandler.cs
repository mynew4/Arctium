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
using WorldServer.Game.Managers;
using WorldServer.Network;

namespace WorldServer.Game.PacketHandler
{
    public class TimeHandler : Globals
    {
        [Opcode(ClientMessage.ReadyForAccountDataTimes, "16135")]
        public static void HandleAccountDataInitialized(ref PacketReader packet, ref WorldClass session)
        {
            WorldMgr.WriteAccountData(AccountDataMasks.GlobalCacheMask, ref session);
        }

        [Opcode(ClientMessage.RequestUITime, "")]
        public static void HandleUITime(ref PacketReader packet, ref WorldClass session)
        {
            PacketWriter uiTime = new PacketWriter(LegacyMessage.UITime);

            uiTime.WriteUnixTime();

            session.Send(uiTime);
        }

        [Opcode(ClientMessage.SetRealmSplitState, "16135")]
        public static void HandleRealmSplitStateResponse(ref PacketReader packet, ref WorldClass session)
        {
            uint realmSplitState = 0;

            PacketWriter realmSplitStateResp = new PacketWriter(LegacyMessage.RealmSplitStateResponse);

            realmSplitStateResp.WriteUInt32(packet.ReadUInt32());
            realmSplitStateResp.WriteUInt32(realmSplitState);
            realmSplitStateResp.WriteCString("01/01/01");

            session.Send(realmSplitStateResp);
        }
    }
}
