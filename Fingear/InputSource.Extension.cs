using System.Collections.Generic;

namespace Fingear
{
    static public class InputSourceExtension
    {
        static public IEnumerable<IInputSource> ToEnumerable(this IInputSource source)
        {
            yield return source;
        }
    }
}