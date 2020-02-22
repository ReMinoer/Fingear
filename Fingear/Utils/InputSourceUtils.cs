using System.Collections.Generic;
using Fingear.Inputs;

namespace Fingear.Utils
{
    static public class InputSourceUtils
    {
        static public IEnumerable<IInputSource> ToEnumerable(this IInputSource source)
        {
            yield return source;
        }
    }
}