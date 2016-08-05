using System.Collections.Generic;

namespace Fingear
{
    public interface IInputSourceEnumerable : IInputSource, IEnumerable<IInputSource>
    {
    }
}