using Framework.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ObjectDefines
{
    // Initialize default values for ObjectUpdate movement
    public class ObjectMovementValues
    {
        public bool HasAnimKits               = false;
        public bool HasUnknown                = false;
        public uint BitCounter                = 0;
        public bool IsSelf                    = false;  // For self update???
        public bool HasUnknown2               = false;
        public bool IsVehicle                 = false;
        public bool Bit2                      = false;
        public bool HasUnknown3               = false;
        public bool HasStationaryPosition     = false;
        public bool HasGoTransportPosition    = false;
        public bool HasUnknown4               = false;
        public bool IsAlive                   = false;
        public uint BitCounter2               = 0;
        public bool Bit3                      = false;
        public bool HasUnknown5               = false;
        public bool HasTarget                 = false;
        public bool Bit1                      = false;
        public bool HasRotation               = false;
        public bool IsTransport               = false;

        public ObjectMovementValues() { }
        public ObjectMovementValues(UpdateFlag updateflags)
        {
            IsSelf                 = (updateflags & UpdateFlag.Self)                != 0;
            IsAlive                = (updateflags & UpdateFlag.Alive)               != 0;
            HasRotation            = (updateflags & UpdateFlag.Rotation)            != 0;
            HasStationaryPosition  = (updateflags & UpdateFlag.StationaryPosition)  != 0;
            HasTarget              = (updateflags & UpdateFlag.Target)              != 0;
            IsTransport            = (updateflags & UpdateFlag.Transport)           != 0;
            HasGoTransportPosition = (updateflags & UpdateFlag.GoTransportPosition) != 0;
            HasAnimKits            = (updateflags & UpdateFlag.AnimKits)            != 0;
            IsVehicle              = (updateflags & UpdateFlag.Vehicle)             != 0;
            HasUnknown             = (updateflags & UpdateFlag.Unknown)             != 0;
            HasUnknown2            = (updateflags & UpdateFlag.Unknown2)            != 0;
            HasUnknown3            = (updateflags & UpdateFlag.Unknown3)            != 0;
            HasUnknown4            = (updateflags & UpdateFlag.Unknown4)            != 0;
            HasUnknown5            = (updateflags & UpdateFlag.Unknown5)            != 0;
        }
    }
}
