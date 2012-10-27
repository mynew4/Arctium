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

using System;

namespace Framework.Constants
{
    [Flags]
    public enum UpdateFieldFlags
    {
        All            = 0x1,
        Self           = 0x2,
        Owner          = 0x4,
        Empath         = 0x10,
        Party          = 0x20,
        UnitAll        = 0x40,
        ViewerDependet = 0x80,
        Urgent         = 0x100,
        UrgentSelfOnly = 0x200
    };
}
