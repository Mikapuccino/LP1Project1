using System;

namespace LampPuzzle
{
    /// <summary>
    /// This enumeration declares one flag called "On" that has the value of 1.
    /// "On" has a shift left from 1 to 0, meaning that 1 means the lamp is on 
    /// and 0 means the lamp is off.
    /// /// </summary>
    [Flags]
    public enum Lamp
    {
        On = 1 << 0
    };
}