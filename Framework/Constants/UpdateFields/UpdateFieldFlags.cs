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
