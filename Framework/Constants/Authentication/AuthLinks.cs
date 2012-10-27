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
 
namespace Framework.Constants.Authentication
{
    public enum ClientLink : byte
    {
        CMD_AUTH_LOGON_CHALLENGE     = 0x00,
        CMD_AUTH_LOGON_PROOF         = 0x01,
        CMD_AUTH_RECONNECT_CHALLENGE = 0x02,
        CMD_AUTH_RECONNECT_PROOF     = 0x03,
        CMD_REALM_LIST               = 0x10,
        CMD_XFER_INITIATE            = 0x30,
        CMD_XFER_DATA                = 0x31
    }

    public enum ServerLink : byte
    {
        CMD_GRUNT_AUTH_CHALLENGE = 0x00,
        CMD_GRUNT_AUTH_VERIFY    = 0x02,
        CMD_GRUNT_CONN_PING      = 0x10,
        CMD_GRUNT_CONN_PONG      = 0x11,
        CMD_GRUNT_HELLO          = 0x20,
        CMD_GRUNT_PROVESESSION   = 0x21,
        CMD_GRUNT_KICK           = 0x24,
        CMD_GRUNT_PCWARNING      = 0x29,
        CMD_GRUNT_STRINGS        = 0x41,
        CMD_GRUNT_SUNKENUPDATE   = 0x44,
        CMD_GRUNT_SUNKEN_ONLINE  = 0x46,
        CMD_GRUNT_CAISTIMEUPDATE = 0x2C
    }
}
