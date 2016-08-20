using System.Collections.Generic;

namespace Fingear
{
    public interface IInputSource
    {
        IEnumerable<IInput> GetAllInputs();
    }
}