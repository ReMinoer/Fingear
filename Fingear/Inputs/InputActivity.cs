using System;

namespace Fingear.Inputs
{
    [Flags]
    public enum InputActivity
    {
        Idle = 0,
        Pressed = 1,
        Changed = 1 << 1,
        Released = Idle | Changed,
        Triggered = Pressed | Changed
    }
}