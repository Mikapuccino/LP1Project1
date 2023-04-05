using System;

namespace LampPuzzle
{
    [Flags]
    public enum Lamp
    {
        On = 1 << 0
    };
}