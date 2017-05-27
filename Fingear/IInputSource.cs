using System.Collections.Generic;

namespace Fingear
{
    public interface IInputSource
    {
        string DisplayName { get; }
        IEnumerable<IInput> InstantiatedInputs { get; }
        IEnumerable<IInput> GetAllInputs();
    }
}