using System;

namespace Framework.Constants
{
    [Flags]
    public enum MovementFlag
    {
        Forward            = 0x1,
        Backward           = 0x2,
        StrafeLeft         = 0x4,
        StrafeRight        = 0x8,
        TurnLeft           = 0x10,
        TurnRight          = 0x20,
        PitchUp            = 0x40,
        PitchDown          = 0x80,
        RunMode            = 0x100,
        Gravity            = 0x200,
        Root               = 0x400,
        Falling            = 0x800,
        FallReset          = 0x1000,
        PendingStop        = 0x2000,
        PendingStrafeStop  = 0x4000,
        PendingForward     = 0x8000,
        PendingBackward    = 0x10000,
        PendingStrafeLeft  = 0x20000,
        PendingStrafeRight = 0x40000,
        PendingRoot        = 0x80000,
        Swim               = 0x100000,
        Ascension          = 0x200000,
        Descension         = 0x400000,
        CanFly             = 0x800000,
        Flight             = 0x1000000,
        Jump               = 0x2000000,
        WalkOnWater        = 0x4000000,
        FeatherFall        = 0x8000000,
        HoverMove          = 0x10000000,
        Collision          = 0x20000000
    }

    [Flags]
    public enum MovementFlag2
    {
        Unknown   = 0x1,
        Unknown2  = 0x2,
        Unknown3  = 0x4,
        Unknown4  = 0x8,
        Unknown5  = 0x10,
        Unknown6  = 0x20,
        Unknown7  = 0x40,
        Unknown8  = 0x80,
        Unknown9  = 0x100,
        Unknown10 = 0x200,
        Unknown11 = 0x400,
        Unknown12 = 0x2000,
        Unknown13 = 0x4000
    }
}
