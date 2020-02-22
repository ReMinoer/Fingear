using System.Collections.Generic;

namespace Fingear.Utils
{
    public delegate T Selector<T>(IEnumerable<T> enumerable);
}