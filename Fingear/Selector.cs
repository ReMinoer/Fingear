using System.Collections.Generic;

namespace Fingear
{
    public delegate T Selector<T>(IEnumerable<T> enumerable);
}