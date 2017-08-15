using System;

namespace Fingear
{
    public enum InputSourceType
    {
        Keyboard,
        Mouse,
        GamePad
    }

    [Flags]
    public enum InputSourceTypes
    {
        Keyboard = 1 << 0,
        Mouse = 1 << 1,
        GamePad = 1 << 2,
        All = Keyboard | Mouse | GamePad
    }

    static public class InputSourceTypeExtension
    {
        static public bool Match(this InputSourceTypes flags, InputSourceType type)
        {
            switch (type)
            {
                case InputSourceType.Keyboard: return (flags & InputSourceTypes.Keyboard) != 0;
                case InputSourceType.Mouse: return (flags & InputSourceTypes.Mouse) != 0;
                case InputSourceType.GamePad: return (flags & InputSourceTypes.GamePad) != 0;
                default: throw new NotSupportedException();
            }
        }
    }
}