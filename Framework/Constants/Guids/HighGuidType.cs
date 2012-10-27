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

namespace Framework.Constants
{
    public enum HighGuidType
    {
        Player          = 0x000, // Other are very buggy
        Group           = 0x1F5,
        MOTransport     = 0x1FC,
        Guild           = 0x10F,
        BattleField     = 0x1F1,
        Instance        = 0x1F4,
        Item            = 0x440,
        Container       = 0x440,
        DynamicObject   = 0xF10,
        Corpse          = 0xF50,
        GameObject      = 0xF11,
        Transport       = 0xF12,
        Unit            = 0xF13,
        Pet             = 0xF14,
        Vehicle         = 0xF15,
    }
}
