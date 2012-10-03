using System;

namespace Framework.Constants
{
    [Flags]
    public enum HighGuidMask
    {
        None          = 0x00,
        Object        = 0x01,
        Item          = 0x02,
        Container     = 0x04,
        Unit          = 0x08,
        Player        = 0x10,
        GameObject    = 0x20,
        DynamicObject = 0x40,
        Corpse        = 0x80,
        Guild         = 0x100
    }
}
